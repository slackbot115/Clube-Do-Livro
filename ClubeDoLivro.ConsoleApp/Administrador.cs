﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Administrador
    {
        private Random random = new Random();

        public Caixa[] caixas = new Caixa[100];
        public int indiceCaixas = 0;

        public Revista[] revistas = new Revista[100];
        public int indiceRevistas = 0;

        public Locador[] locadores = new Locador[100];
        public int indiceLocadores = 0;

        public Emprestimo[] emprestimos = new Emprestimo[100];
        public int indiceEmprestimos = 0;

        public void GerenciadorOpcoesMenus()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Gerenciamento Caixas");
                Console.WriteLine("2 - Gerenciamento Revistas");
                Console.WriteLine("3 - Gerenciamento Locadores");
                Console.WriteLine("4 - Gerenciamento Emprestimos");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 0)
                {
                    Console.WriteLine("Fechando o programa...");
                    break;
                }
                else if (opcao == 1)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Cadastrar Caixa");
                    Console.WriteLine("2 - Listar Caixa");
                    Console.WriteLine("3 - Editar Caixa");
                    Console.WriteLine("4 - Excluir Caixa");
                    Console.WriteLine("0 - Voltar");
                    Console.Write("Digite a opção desejada: ");
                    int opcaoCaixas = int.Parse(Console.ReadLine());
                    if (opcaoCaixas == 0)
                    {
                        continue;
                    }
                    else if (opcaoCaixas == 1)
                    {
                        CadastrarCaixa();
                    }
                    else if (opcaoCaixas == 2)
                    {
                        ListarCaixas();
                        ExibirMensagemSucesso("\nListagem de caixas realizado com sucesso...");
                    }
                    else if (opcaoCaixas == 3)
                    {
                        EditarCaixas();
                    }
                    else if (opcaoCaixas == 4)
                    {
                        ExibirMensagemSucesso("Exclusão de caixa realizado com sucesso...");
                    }
                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Cadastrar Revistas");
                    Console.WriteLine("2 - Listar Revistas");
                    Console.WriteLine("3 - Editar Revistas");
                    Console.WriteLine("4 - Excluir Revistas");
                    Console.WriteLine("0 - Voltar");
                    int opcaoRevistas = int.Parse(Console.ReadLine());
                    if (opcaoRevistas == 0)
                    {
                        continue;
                    }
                    else if (opcaoRevistas == 1)
                    {
                        CadastrarRevista();
                    }
                    else if (opcaoRevistas == 2)
                    {
                        ListarRevistas();
                        ExibirMensagemSucesso("Listagem de revistas realizado com sucesso...");
                    }
                    else if (opcaoRevistas == 3)
                    {
                        EditarRevista();
                    }
                    else if (opcaoRevistas == 4)
                    {
                        ExibirMensagemSucesso("Exclusão de revista realizado com sucesso...");
                    }
                }
                else if (opcao == 3)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Cadastrar Locadores");
                    Console.WriteLine("2 - Listar Locadores");
                    Console.WriteLine("3 - Editar Locadores");
                    Console.WriteLine("4 - Excluir Locadores");
                    Console.WriteLine("0 - Voltar");
                    int opcaoLocadores = int.Parse(Console.ReadLine());
                    if (opcaoLocadores == 0)
                    {
                        continue;
                    }
                    else if (opcaoLocadores == 1)
                    {
                        CadastrarLocador();
                        ExibirMensagemSucesso("Cadastro de locador realizado com sucesso...");
                    }
                    else if (opcaoLocadores == 2)
                    {
                        ListarLocadores();
                        ExibirMensagemSucesso("Listagem de locadores realizado com sucesso...");
                    }
                    else if (opcaoLocadores == 3)
                    {
                        EditarLocador();
                    }
                    else if (opcaoLocadores == 4)
                    {
                        ExibirMensagemSucesso("Exclusão de locador realizado com sucesso...");
                    }
                }
                else if (opcao == 4)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Cadastrar emprestimos");
                    Console.WriteLine("2 - Listar emprestimos");
                    Console.WriteLine("3 - Editar emprestimos");
                    Console.WriteLine("4 - Excluir emprestimos");
                    Console.WriteLine("5 - Finalizar empréstimo");
                    Console.WriteLine("6 - Visualizar empréstimos do dia");
                    Console.WriteLine("7 - Visualizar empréstimos do mês");
                    Console.WriteLine("0 - Voltar");
                    int opcaoEmprestimos = int.Parse(Console.ReadLine());
                    if (opcaoEmprestimos == 0)
                    {
                        continue;
                    }
                    else if (opcaoEmprestimos == 1)
                    {
                        CadastrarEmprestimo();
                    }
                    else if (opcaoEmprestimos == 2)
                    {
                        ListarEmprestimos();
                        ExibirMensagemSucesso("Listagem de emprestimos realizado com sucesso...");
                    }
                    else if (opcaoEmprestimos == 3)
                    {
                        EditarEmprestimo();
                    }
                    else if (opcaoEmprestimos == 4)
                    {
                        ExibirMensagemSucesso("Exclusão de emprestimo realizado com sucesso...");
                    }
                    else if (opcaoEmprestimos == 5)
                    {
                        FinalizarEmprestimo();
                    }
                    else if (opcaoEmprestimos == 6)
                    {
                        VisualizarEmprestimoDiario();
                    }
                    else if(opcaoEmprestimos == 7)
                    {
                        VisualizarEmprestimoMensal();
                    }
                }
            }
        }

        #region CRUD Emprestimos

        public void FinalizarEmprestimo()
        {
            if (VerificarSeExistemEmprestimos())
            {
                Console.WriteLine("Exibindo emprestimos em aberto: \n");
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i] != null && emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{i} - Nome locador: {emprestimos[i].locador.nome}\nTítulo: {emprestimos[i].revista.titulo}\nNº Edição revista: {emprestimos[i].revista.numeroEdicao}");
                        Console.WriteLine($"Data de empréstimo: {emprestimos[i].dataEmprestimo.Date}\nData de devolução: {emprestimos[i].dataDevolucao.Date}\n");
                    }
                }
                Console.ResetColor();
                Console.Write("Escolha o indice para fechar o empréstimo: ");
                int indiceEmprestimo = int.Parse(Console.ReadLine());
                Emprestimo emprestimo = emprestimos[indiceEmprestimo];
                emprestimo.revista.estaAlugada = false;
                emprestimo.locador.revistaAlugada = null;

                ExibirMensagemSucesso("Fechamento de emprestimo realizada com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem emprestimos para listar...");
            }
        }

        public void VisualizarEmprestimoMensal()
        {
            if (VerificarSeExistemEmprestimos())
            {
                Console.WriteLine("Empréstimos realizados no mês atual: \n");
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i].dataEmprestimo.Month == DateTime.Now.Month && !emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{emprestimos[i].locador.nome} alugou {emprestimos[i].revista.titulo} até {emprestimos[i].dataDevolucao.Date}, mas já foi devolvida\n");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i].dataEmprestimo.Month == DateTime.Now.Month && emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{emprestimos[i].locador.nome} alugou {emprestimos[i].revista.titulo} até {emprestimos[i].dataDevolucao.Date}\n");
                    }
                }
                Console.ResetColor();
                ExibirMensagemSucesso("Empréstimos mensais listados com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem emprestimos para listar...");
            }
        }

        public void VisualizarEmprestimoDiario()
        {
            if (VerificarSeExistemEmprestimos())
            {
                Console.WriteLine("Empréstimos realizados no dia de hoje (em aberto): \n");
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i].dataEmprestimo.Date == DateTime.Now.Date && emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{emprestimos[i].locador.nome} alugou {emprestimos[i].revista.titulo} até {emprestimos[i].dataDevolucao.Date}\n");
                    }
                }
                ExibirMensagemSucesso("Empréstimos diários listados com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem emprestimos para listar...");
            }
        }

        public void EditarEmprestimo()
        {
            Console.WriteLine("Editando emprestimo: ");
            int indiceEmprestimoEdicao = ReceberItemEListarEmprestimos();
            if (indiceEmprestimoEdicao != -1)
            {
                Emprestimo emprestimo = emprestimos[indiceEmprestimoEdicao];

                Console.WriteLine("Digite a data de devolução: ");
                emprestimo.dataDevolucao = DateTime.Parse(Console.ReadLine());

                ExibirMensagemSucesso("Edição de emprestimo realizada com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem emprestimos para editar...");
            }
        }

        public int ReceberItemEListarEmprestimos()
        {
            if (VerificarSeExistemEmprestimos())
            {
                ListarEmprestimos();
                Console.Write("\nEscolha um emprestimo: ");
                int indiceEscolhido = int.Parse(Console.ReadLine());
                return indiceEscolhido;
            }
            else
            {
                return -1;
            }
        }

        public bool VerificarSeExistemEmprestimos()
        {
            if (indiceEmprestimos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListarEmprestimos()
        {
            if (VerificarSeExistemEmprestimos())
            {
                Console.WriteLine("Exibindo emprestimos: \n");

                ExibirMensagemColorida("Revistas livres: verde", ConsoleColor.Green);
                ExibirMensagemColorida("Revistas alugadas: vermelhas", ConsoleColor.Red);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i] != null && !emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{i}: Locador: {emprestimos[i].locador.nome}\nTítulo: {emprestimos[i].revista.titulo}\nNº Edição revista: {emprestimos[i].revista.numeroEdicao}");
                        Console.WriteLine($"Data de empréstimo: {emprestimos[i].dataEmprestimo.Date}\nData de devolução: {emprestimos[i].dataDevolucao.Date}\n");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < indiceEmprestimos; i++)
                {
                    if (emprestimos[i] != null && emprestimos[i].revista.estaAlugada)
                    {
                        Console.WriteLine($"{i} - Nome locador: {emprestimos[i].locador.nome}\nTítulo: {emprestimos[i].revista.titulo}\nNº Edição revista: {emprestimos[i].revista.numeroEdicao}");
                        Console.WriteLine($"Data de empréstimo: {emprestimos[i].dataEmprestimo.Date}\nData de devolução: {emprestimos[i].dataDevolucao.Date}\n");
                    }
                }
                Console.ResetColor();
            }
            else
            {
                ExibirMensagemAviso("Sem emprestimos para listar...");
            }
        }

        public void ListarRevistasLivres()
        {
            if (VerificarSeExistemRevistas())
            {
                for (int i = 0; i < indiceRevistas; i++)
                {
                    if (revistas[i] != null && !revistas[i].estaAlugada)
                    {
                        Console.WriteLine($"{i}: Título: {revistas[i].titulo}\nNº Edição: {revistas[i].numeroEdicao}ª\n");
                    }
                }
            }
            else
            {
                ExibirMensagemAviso("Sem revistas para listar...");
            }
        }

        public int ReceberEListarRevistasLivres()
        {
            if (VerificarSeExistemRevistas())
            {
                ListarRevistasLivres();
                Console.Write("Escolha uma revista: ");
                int indiceEscolhido = int.Parse(Console.ReadLine());
                return indiceEscolhido;
            }
            else
            {
                return -1;
            }
        }

        public void ListarLocadoresLivres()
        {
            if (VerificarSeExistemLocadores())
            {
                for (int i = 0; i < indiceLocadores; i++)
                {
                    if (locadores[i] != null && locadores[i].revistaAlugada == null)
                    {
                        Console.WriteLine($"{i}: {locadores[i].nome}\nTelefone: {locadores[i].telefone}\n");
                    }
                }
            }
            else
            {
                ExibirMensagemAviso("Sem locadores para listar...");
            }
        }

        public int ReceberEListarLocadoresLivres()
        {
            if (VerificarSeExistemLocadores())
            {
                ListarLocadoresLivres();
                Console.Write("Digite o índice do locador: ");
                int indiceLocador = int.Parse(Console.ReadLine());
                return indiceLocador;
            }
            else
            {
                return -1;
            }
        }

        public void CadastrarEmprestimo()
        {
            if (VerificarSeExistemLocadores() && VerificarSeExistemRevistas())
            {
                Emprestimo emprestimo = new Emprestimo();
                Console.WriteLine("Escolha o locador: ");
                int indiceEscolhidoLocador = ReceberEListarLocadoresLivres();
                emprestimo.locador = locadores[indiceEscolhidoLocador];

                Console.WriteLine("\nEscolha a revista que deseja: ");
                int indiceEscolhidoRevista = ReceberEListarRevistasLivres();
                emprestimo.revista = revistas[indiceEscolhidoRevista];
                emprestimo.revista.estaAlugada = true;
                emprestimo.locador.revistaAlugada = revistas[indiceEscolhidoRevista];

                emprestimo.dataEmprestimo = DateTime.Now.Date;
                Console.Write("Digite a data de devolução: ");
                emprestimo.dataDevolucao = DateTime.Parse(Console.ReadLine());

                emprestimos[indiceEmprestimos] = emprestimo;
                indiceEmprestimos++;

                ExibirMensagemSucesso("Cadastro de emprestimo realizado com sucesso...");
            }
            else
            {
                ExibirMensagemErro("Impossível criar emprestimo sem locadores e revistas...");
            }
        }

        #endregion

        #region CRUD Locadores

        public void EditarLocador()
        {
            Console.WriteLine("Editando locador: ");
            int indiceLocadorEdicao = ReceberItemEListarLocadores();
            if (indiceLocadorEdicao != -1)
            {
                Locador locador = locadores[indiceLocadorEdicao];
                Console.Write("Digite o nome do locador: ");
                locador.nome = Console.ReadLine();
                Console.Write("Digite o nome do responsável: ");
                locador.nomeResponsavel = Console.ReadLine();
                Console.Write("Digite o telefone: ");
                locador.telefone = Console.ReadLine();
                Console.Write("Digite o endereço: ");
                locador.endereco = Console.ReadLine();

                ExibirMensagemSucesso("Edição de locador realizado com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem locadores para editar...");
            }
        }

        public bool VerificarSeExistemLocadores()
        {
            if (indiceLocadores > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListarLocadores()
        {
            if (VerificarSeExistemLocadores())
            {
                for (int i = 0; i < indiceLocadores; i++)
                {
                    if (locadores[i] != null)
                    {
                        Console.WriteLine($"{i}: {locadores[i].nome}\nTelefone: {locadores[i].telefone}");
                    }
                }
            }
            else
            {
                ExibirMensagemAviso("Sem locadores para listar...");
            }
        }

        public int ReceberItemEListarLocadores()
        {
            if (VerificarSeExistemLocadores())
            {
                ListarLocadores();
                Console.Write("\nEscolha um locador: ");
                int indiceEscolhido = int.Parse(Console.ReadLine());
                return indiceEscolhido;
            }
            else
            {
                return -1;
            }
        }

        public void CadastrarLocador()
        {
            Locador locador = new Locador();
            Console.Write("Digite o nome do locador: ");
            locador.nome = Console.ReadLine();
            Console.Write("Digite o nome do responsável: ");
            locador.nomeResponsavel = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            locador.telefone = Console.ReadLine();
            Console.Write("Digite o endereço: ");
            locador.endereco = Console.ReadLine();
            locador.revistaAlugada = null;

            locadores[indiceLocadores] = locador;
            indiceLocadores++;
        }

        #endregion

        #region CRUD Revistas

        public void EditarRevista()
        {
            Console.WriteLine("Editando revista: ");
            int indiceRevistaEdicao = ReceberItemEListarRevistas();
            if (indiceRevistaEdicao != -1)
            {
                Revista revista = revistas[indiceRevistaEdicao];
                int indiceCaixaRecebido = ReceberItemEListarCaixas();
                revista.caixa = caixas[indiceCaixaRecebido];
                Console.Write("Digite o título da revista: ");
                revista.titulo = Console.ReadLine();
                Console.Write("Digite o ano: ");
                revista.anoRevista = int.Parse(Console.ReadLine());
                Console.Write("Digite a edição: ");
                revista.numeroEdicao = Console.ReadLine();
                revista.tipoColecao = caixas[indiceCaixaRecebido].etiqueta;
                revista.estaAlugada = true;

                ExibirMensagemSucesso("Edição de revista realizada com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem revistas para editar...");
            }
        }

        public bool VerificarSeExistemRevistas()
        {
            if (indiceRevistas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListarRevistas()
        {
            if (VerificarSeExistemRevistas())
            {
                for (int i = 0; i < indiceRevistas; i++)
                {
                    if (revistas[i] != null)
                    {
                        Console.WriteLine($"{i}: Título: {revistas[i].titulo}\nNº Edição: {revistas[i].numeroEdicao}ª\n");
                    }
                }
            }
            else
            {
                ExibirMensagemAviso("Sem revistas para listar...");
            }
        }

        public int ReceberItemEListarRevistas()
        {
            if (VerificarSeExistemRevistas())
            {
                ListarRevistas();
                Console.Write("\nEscolha uma revista: ");
                int indiceEscolhido = int.Parse(Console.ReadLine());
                return indiceEscolhido;
            }
            else
            {
                return -1;
            }
        }

        public void CadastrarRevista()
        {
            if (VerificarSeExistemCaixas())
            {
                Revista revista = new Revista();
                int indiceCaixaRecebido = ReceberItemEListarCaixas();
                revista.caixa = caixas[indiceCaixaRecebido];
                Console.Write("Digite o título da revista: ");
                revista.titulo = Console.ReadLine();
                Console.Write("Digite o ano: ");
                revista.anoRevista = int.Parse(Console.ReadLine());
                Console.Write("Digite a edição: ");
                revista.numeroEdicao = Console.ReadLine();
                revista.tipoColecao = caixas[indiceCaixaRecebido].etiqueta;

                revistas[indiceRevistas] = revista;
                indiceRevistas++;

                ExibirMensagemSucesso("Cadastro de revista realizado com sucesso...");
            }
            else
            {
                ExibirMensagemErro("Impossível criar revistas sem caixas...");
            }
        }

        #endregion

        #region CRUD Caixas

        public void EditarCaixas()
        {
            Console.WriteLine("Editando caixa: ");
            int indiceCaixaEdicao = ReceberItemEListarCaixas();
            if(indiceCaixaEdicao != -1)
            {
                Caixa caixa = caixas[indiceCaixaEdicao];
                Console.Write("Digite a etiqueta da caixa: ");
                caixa.etiqueta = Console.ReadLine();
                Console.Write("Digite o número da caixa: ");
                caixa.numero = Console.ReadLine();

                ExibirMensagemSucesso("Edição de caixa realizado com sucesso...");
            }
            else
            {
                ExibirMensagemAviso("Sem caixas para editar...");
            }
        }

        public bool VerificarSeExistemCaixas()
        {
            if (indiceCaixas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListarCaixas()
        {
            if (VerificarSeExistemCaixas())
            {
                Console.WriteLine("Exibindo caixas (etiquetas): ");
                for (int i = 0; i < indiceCaixas; i++)
                {
                    if (caixas[i] != null)
                    {
                        ExibirMensagemColorida($"{i}: {caixas[i].etiqueta}", caixas[i].cor);
                    }
                }
            }
            else
            {
                ExibirMensagemAviso("Sem caixas para listar...");
            }
            
        }

        public int ReceberItemEListarCaixas()
        {
            if (VerificarSeExistemCaixas())
            {
                ListarCaixas();
                Console.Write("Escolha uma caixa: ");
                int indiceEscolhido = int.Parse(Console.ReadLine());
                return indiceEscolhido;
            }
            else
            {
                return -1;
            }
        }

        public void CadastrarCaixa()
        {
            Caixa caixa = new Caixa();
            caixa.cor = EscolherCorAleatoria();
            Console.Write("Digite a etiqueta da caixa: ");
            caixa.etiqueta = Console.ReadLine();
            Console.Write("Digite o número da caixa: ");
            caixa.numero = Console.ReadLine();

            caixas[indiceCaixas] = caixa;
            indiceCaixas++;

            ExibirMensagemColorida($"Cor da caixa: {caixa.cor}", caixa.cor);

            ExibirMensagemSucesso("\nCadastro de caixa realizado com sucesso...");
        }

        #endregion

        #region Modificador de Mensagens
        public void ExibirMensagemSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }

        public void ExibirMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }

        public void ExibirMensagemAviso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadKey();
        }

        public void ExibirMensagemColorida(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        #endregion

        #region Metodos Auxiliares
        
        public ConsoleColor EscolherCorAleatoria()
        {
            var corAleatoria = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)corAleatoria.GetValue(random.Next(corAleatoria.Length));
        }
        
        #endregion

    }
}