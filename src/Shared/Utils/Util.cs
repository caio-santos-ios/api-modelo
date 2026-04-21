using api_infor_cell.src.Models;
using Newtonsoft.Json;

namespace api_infor_cell.src.Shared.Utils
{
    public static class Util
    {
        public static void ConsoleLog(dynamic obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public static dynamic GenerateCodeAccess(int minutesExpiration = 15)
        {
            return new
            {
                CodeAccess = new Random().Next(100000, 999999).ToString(),
                CodeAccessExpiration = DateTime.UtcNow.AddMinutes(minutesExpiration)
            };
        }

        public static string NormalizeMessageLogger(int statusCode, string message)
        {
            string responseMessage;

            if (statusCode > 204)
            {
                if (message.Contains("Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. "))
                {
                    responseMessage = message.Split("Ocorreu um erro inesperado. Por favor, tente novamente mais tarde. ")[1];
                }
                else
                {
                    responseMessage = message;
                }
            }
            else
            {
                responseMessage = message;
            }

            return responseMessage;
        }

        public static List<Module> ListModules()
        {
            List<Module> modules = new()
            {
                new()
                {
                    Code = "C",
                    Description = "Chat",
                    Routines = new()
                    {
                        new() { Code = "C1", Description = "Chat", Permissions = new() { Read = true, Create = true, Update = true, Delete = true } }
                    }
                },
                new()
                {
                    Code = "A",
                    Description = "Configurações",
                    Routines = new()
                    {
                        new() { Code = "A1", Description = "Logs",      Permissions = new() { Read = false, Create = false, Update = false, Delete = false } },
                        new() { Code = "A2", Description = "Templates", Permissions = new() { Read = false, Create = false, Update = false, Delete = false } },
                        new() { Code = "A3", Description = "Triggers",  Permissions = new() { Read = false, Create = false, Update = false, Delete = false } },
                        new() { Code = "A4", Description = "Auditoria", Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                    }
                },
                new()
                {
                    Code = "B",
                    Description = "Cadastros",
                    Routines = new()
                    {
                        new() { Code = "B1", Description = "Usuários",          Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "B2", Description = "Perfil de Usuário", Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "B3", Description = "Clientes",          Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "B4", Description = "Fornecedores",      Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                    }
                },
                new()
                {
                    Code = "D",
                    Description = "Financeiro",
                    Routines = new()
                    {
                        new() { Code = "D1", Description = "Formas de Pagamentos", Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "D2", Description = "Contas a Receber",     Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "D3", Description = "Contas a Pagar",       Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "D4", Description = "Plano de Contas",      Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                        new() { Code = "D5", Description = "DRE",                  Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                    }
                },
                new()
                {
                    Code = "E",
                    Description = "Comercial",
                    Routines = new()
                    {
                        new() { Code = "E1", Description = "Ordem de Serviço", Permissions = new() { Read = true, Create = true, Update = true, Delete = true } },
                    }
                }
            };

            return modules;
        }
    }
}