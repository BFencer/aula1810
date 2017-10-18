using System;

namespace aula1810
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string CPF;
                string CPFaux;
                int PrimeiroDigito;
                int SegundoDigito;

                Console.WriteLine("Digite seu cpf:");

                CPF = Console.ReadLine();

                if (CPF.Length != 11)
                {   
                    throw new Exception("CPF inválido");
                }

                PrimeiroDigito = Modulo(11, CPF);

                CPFaux = CPF + PrimeiroDigito.ToString();
                SegundoDigito = Modulo(12, CPFaux, true);

                if(CPF.Substring(9,1) == PrimeiroDigito.ToString() && CPF.Substring(10,1) == SegundoDigito.ToString())
                {
                    Console.WriteLine("CPF Válido");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("CPF inválido");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
         static int Modulo(int NumMod, string CPF, bool seg = false)
        {
            int Soma = 0;
            int NumAux = NumMod;

             for(int i = 1; i <= (!seg?9:10); i++)
            {
                NumAux -= 1;       
                Soma += int.Parse(CPF.Substring((i-1),1)) * NumAux; 
            }

            return (Soma % 11 < 2?0:11 - (Soma % 11));
        }
    }
}
