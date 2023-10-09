using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace AssinadorPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Caminho para o arquivo PDF a ser assinado
            string pdfFilePath = "./cet.pdf";

            // Caminho para o arquivo PDF assinado
            string signedPdfFilePath = "_arquivo_assinado.pdf";

            // Caminho para o arquivo de certificado digital
            string certificateFilePath = "certificado.pfx";
            string certificatePassword = "redzod";

            try
            {
                // Carregue o arquivo PDF original
                using (FileStream pdfFileStream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.Read))
                {
                    // Crie um novo documento PDF assinado
                    using (FileStream signedPdfFileStream = new FileStream(signedPdfFilePath, FileMode.Create, FileAccess.Write))
                    {
                        PdfReader pdfReader = new PdfReader(pdfFileStream);
                        PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdfFileStream, '\0', null, true);

                        // Crie um campo de assinatura
                        PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                        signatureAppearance.Reason = "Motivo da assinatura";
                        signatureAppearance.Location = "Local da assinatura";
                        signatureAppearance.SetVisibleSignature(new Rectangle(100, 100, 250, 150), pdfReader.NumberOfPages, "assinatura");

                        // Carregue o certificado digital
                        Pkcs12Store pkcs12Store = new Pkcs12Store(new FileStream(certificateFilePath, FileMode.Open), certificatePassword.ToCharArray());
                        string alias = null;
                        foreach (string entryAlias in pkcs12Store.Aliases)
                        {
                            alias = entryAlias;
                            if (pkcs12Store.IsKeyEntry(alias))
                                break;
                        }
                        AsymmetricKeyEntry privateKey = pkcs12Store.GetKey(alias);

                        // Crie uma assinatura digital
                        IExternalSignature signature = new PrivateKeySignature(privateKey.Key, DigestAlgorithms.SHA256);

                        // Converta o certificado digital para o tipo correto
                        X509CertificateEntry[] chain = pkcs12Store.GetCertificateChain(alias);
                        Org.BouncyCastle.X509.X509Certificate bcCert = chain[0].Certificate;

                        // Assine o documento PDF
                        MakeSignature.SignDetached(signatureAppearance, signature, new[] { bcCert }, null, null, null, 0, CryptoStandard.CMS);

                        Console.WriteLine("Arquivo assinado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao assinar o arquivo PDF: " + ex.Message);
            }
        }
    }
}
