using System;

namespace ConsoleExemplo
{
    class Program
    {
        static int dia;
        static int mes;
        static int ano;
        static int hora;
        static int minuto;

        static void Main(string[] args)
        {
            string DataRetorno = ChangeDate("04/03/2010 23:00", '+', 4000); //04/03/2010 17:40
            Console.WriteLine(DataRetorno);
            Console.ReadKey();
        }

        private static string ChangeDate(string date, char op, long value)
        {
            //verificar se o operador está correto
            string Operador = Convert.ToString(op);

            if ((!Operador.Equals("+")) && (!Operador.Equals("-")))
            {
                return "O operador precisa ser o sinal de '+' ou '-' ";
            }

            string[] partes = date.Split(' ');
            string[] partesData = partes[0].Split('/');
            string[] partesHora = partes[1].Split(':');

            dia = int.Parse(partesData[0]);
            mes = int.Parse(partesData[1]);
            ano = int.Parse(partesData[2]);
            hora = int.Parse(partesHora[0]);
            minuto = int.Parse(partesHora[1]);

            //se o valor for menor que 0, a operação e positivo
            if (value < 0)
            {
                Operador = "+";
            }

            
            if (Operador == "+")
            {
                incremento(value);
            }
            else
            {
                decremento(value);
            }
            return dia.ToString(@"00") + "/" + mes.ToString(@"00") + "/" + ano + " " + hora + ":" + minuto;
        }


        private static void incremento(long value)
        {
            for (int i = 0; i < value; i++)
            {
                if (minuto == 59)
                {
                    minuto = 0;
                    hora++;
                    if (hora > 23)
                    {
                        hora = 0;
                        dia++;
                        if (estoraMes())
                        {
                            dia = 1;
                            mes++;
                            if (mes > 12)
                            {
                                mes = 1;
                                ano++;
                            }
                        }
                    }
                }
                else
                {
                    minuto++;
                }
            }
        }

        private static void decremento(long value)
        {
            for (int i = 0; i < value; i++)
            {
                if (minuto == 0)
                {
                    minuto = 59;
                    hora--;
                    if (hora < 0)
                    {
                        hora = 23;
                        dia--;
                        if (dia == 0)
                        {
                            mes--;
                            if (mes == 0)
                            {
                                mes = 12;
                                ano--;
                            }
                            dia = GetMesUltimoDia();
                        }
                    }
                }
                else
                {
                    minuto--;
                }
            }
        }

        private static bool estoraMes()
        {
            if (mes == 2)
            {
                if (!isBisexto())
                {
                    return true;
                }
                else
                {
                    return dia == 29;
                }
            }
            else
            {
                if (dia == 31)
                {
                    return true;
                }
                else
                {
                    if (dia == 30)
                    {
                        return !(mes == 1
                            || mes == 3
                            || mes == 5
                            || mes == 7
                            || mes == 8
                            || mes == 10
                            || mes == 12);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private static bool isBisexto()
        {
            return ano % 400 == 0 || ano % 4 == 0 && ano % 100 != 0;
        }

        private static int GetMesUltimoDia()
        {
            if (mes == 2)
            {
                return 28;
            }
            else
            {
                if (mes == 1
                    || mes == 3
                    || mes == 5
                    || mes == 7
                    || mes == 8
                    || mes == 10
                    || mes == 12)
                {
                    return 31;
                }
                else
                {
                    return 30;
                }
            }
        }

    }
}