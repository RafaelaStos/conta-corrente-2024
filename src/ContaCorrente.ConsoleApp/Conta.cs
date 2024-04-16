

namespace ContaCorrente.ConsoleApp
{
    public class Conta
    {

        public int numConta;
        public double saldo;
        public bool tipoConta;
        public double limite;
        public Cliente titular;

        public Movimentacao[] movimentacoesRealizadas;

        public int qtdMovimentação()
        {
            int idConta = -1;
            for (int i = 0; i < movimentacoesRealizadas.Length; i++)
            {
                if (movimentacoesRealizadas[i] == null)
                    idConta = i;

            }
            return idConta;
        }
        
        public void Sacar(double saque)
        {
            if (saque < saldo)
            {
                Movimentacao novaOperacao = new Movimentacao();

                int idConta = qtdMovimentação();
                novaOperacao.valor = saque;
                novaOperacao.tipoMovimentacao = "Debito";


                double novoSaldo = saldo - saque;
                saldo = novoSaldo;

                Console.WriteLine("Saque realizado com sucesso!\n");
                movimentacoesRealizadas[idConta] = novaOperacao;
            }
            else
                Console.WriteLine("Não foi possivel realizar o saque. Saldo insuficiente!\n");
        }
       

        public void Depositar(double deposito)
        {
            int idConta = qtdMovimentação();
            Movimentacao novaOperacao = new Movimentacao();
            novaOperacao.valor = deposito;
            novaOperacao.tipoMovimentacao = "Credito";

            this.saldo += deposito;

            movimentacoesRealizadas[idConta] = novaOperacao;
            Console.WriteLine("Deposito realizado com sucesso!");
        }

        public void Transferir(double valor,Conta destino)
        {
            if (valor < saldo)
            {
                int idConta = qtdMovimentação();
                Movimentacao novaOperacao = new Movimentacao();
                novaOperacao.valor = valor;
                novaOperacao.tipoMovimentacao = "Transferencia";
                saldo -= valor;
                destino.saldo += valor;

                movimentacoesRealizadas[idConta] = novaOperacao; 
                Console.WriteLine($"\nTransferencia realizada para conta:{destino.numConta} | Titular: {destino.titular.nome}");
                Console.WriteLine("\nTransferencia Realizada com Sucesso!");
               
            }

            else Console.WriteLine("Não foi possivel realizar a Transferencia. Saldo insuficiente!");


        }

        public void Extrato()
        {

            string Conta;
            if (tipoConta == true)
                Conta = "Especial";

            else
                Conta = "Normal";

            Console.WriteLine($"Titular: {titular.nome} | cpf: {titular.cpf}\nN° Conta:{numConta}");
            Console.WriteLine("************ EXTRATO ************");
            Console.WriteLine($"\nSaldo da conta: {saldo}\nTipo de conta: {Conta } \nLimite da Conta: {limite}");

            Console.WriteLine("\n************ MOVIMENTAÇÕES DA CONTA ************\n");

            for (int i = 0; i < movimentacoesRealizadas.Length; i++)
            {
                if (movimentacoesRealizadas[i] != null)
                {
                    if (movimentacoesRealizadas[i].tipoMovimentacao == "Debito")
                    {
                        Console.WriteLine($"\nSaque realizado da conta {numConta} com o valor de  {movimentacoesRealizadas[i].valor}" );
                    }
                    else if (movimentacoesRealizadas[i].tipoMovimentacao == "Credito")
                    {
                        Console.WriteLine($"\nDeposito efetuado na conta {numConta} com o valor de  {movimentacoesRealizadas[i].valor}");

                    }
                    else if (movimentacoesRealizadas[i].tipoMovimentacao == "Tranferencia")
                    {

                        Console.WriteLine($"\nTransferencia efetuada da conta {numConta} com o valor de  {movimentacoesRealizadas[i].valor}");


                    }
                }

            }
            Console.WriteLine("\n*******************************\n");
        }

        public void MostraSaldo()
        {
            Console.WriteLine("************ SALDO ************");
            Console.WriteLine($"\n{titular.nome}\nConta {numConta} o Saldo é de {saldo}");
            Console.WriteLine("\n*******************************");
        }
        public double Saldo()
        {
            return saldo;
        }




    }
}
