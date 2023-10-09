namespace CalculadoraDominio
{
    public class calculadora
    {
        public int somar(int a, int b)
        {
            return a + b;
        }

        public int subtracao(int a, int b)
        {
            return a - b;
        }

        public int multiplicacao(int a, int b)
        {
            return a * b;
        }

        public int divisao(int a, int b)
        {
            return a / b;
        }

        public int fatorial(int a)
        {
            int resul = 1;
            for (int i = 1; i <= a; i++)
            {
                resul *= i;
            }

            return resul;
        }
    }
}
