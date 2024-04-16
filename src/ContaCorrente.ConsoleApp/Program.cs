using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();

            conta1.titular = new Cliente();
            conta1.titular.nome = "Rafaela dos Santos Morais";
            conta1.titular.cpf = "012.233.499-00";

            conta1.numConta = 12;
            conta1.saldo = 1000;
            conta1.limite = 0;
            conta1.tipoConta = false;
            conta1.movimentacoesRealizadas = new Movimentacao[10];

            conta1.MostraSaldo();
            Console.ReadLine();
            Console.Clear();

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200);
            conta1.Extrato();
            Console.ReadLine();
            Console.Clear();

            Conta conta2 = new Conta();
            conta2.titular = new Cliente();
            conta2.titular.nome = "Eliabe Morais";
            conta2.titular.cpf = "064.728.879-69";
            conta2.numConta = 1235;
            conta2.saldo = 1000;
            conta2.tipoConta = true;
            conta2.limite = 300;
            conta2.movimentacoesRealizadas = new Movimentacao[10];

            conta2.MostraSaldo();
            Console.ReadLine();
            Console.Clear();

            conta2.Sacar(200);
            conta2.Depositar(300);
            conta2.Depositar(500);
            conta2.Sacar(200);
            conta2.Extrato();
            Console.ReadLine();
            Console.Clear();

            #region Movimentação conta 1

            conta1.Extrato();

            conta1.MostraSaldo();

            conta1.Depositar(15);

            conta1.MostraSaldo();

            // inválido
            conta1.Sacar(18000);

            // válido
            conta1.Sacar(15);

            conta1.Extrato();

            Console.ReadLine();
            Console.Clear();
            #endregion



            #region Movimentação conta 2
            conta2.Extrato();

            conta2.MostraSaldo();

            conta2.Depositar(15);

            conta2.MostraSaldo();

            //inválido
            conta2.Sacar(18000);

            //válido
            conta2.Sacar(15);

            conta2.Extrato();

            Console.ReadLine();
            Console.Clear();
            #endregion


            #region transferencia da conta 1 para conta 2
            conta1.Transferir(15000, conta2);

        
            conta1.Transferir(15, conta2);

            conta1.Extrato();
            #endregion

            #region transferencia da conta 2 para conta 1
            conta2.Transferir(115000, conta1);

          
            conta2.Transferir(20, conta1);
            #endregion

            Console.ReadLine();
            Console.Clear();

            #region Saldo final das contas
            conta2.Extrato();
            conta2.MostraSaldo();

            Console.ReadLine();
            Console.Clear();

            conta1.Extrato();
            conta1.MostraSaldo();
            #endregion


        }
    }
}
