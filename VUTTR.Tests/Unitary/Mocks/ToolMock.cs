using System.Collections.Generic;
using System.Linq;
using VUTTR.Domain.Models;

namespace VUTTR.Tests.Unitary.Mocks
{
    public class ToolMock
    {
        private readonly List<Tool> toolsMock = new List<Tool>{
            new Tool {
                id = 1,
                title = "Descrição de Teste",
                description = "Descrição de Teste",
                link = "www.descricao.com.br",
                Tags = new List<Tag> {
                    new Tag {
                        description = "descrição"
                    },
                    new Tag {
                        description = "teste"
                    }
                }
            },
            new Tool {
                id = 2,
                title = "Teste de Descrição",
                description = "Teste de Descrição",
                link = "www.Teste.com.br",
                Tags = new List<Tag> {
                    new Tag {
                        description = "outro"
                    },
                    new Tag {
                        description = "teste"
                    }
                }
            }
        };
    
        public Tool GetToolMock(int id)
        {
            return toolsMock.FirstOrDefault(x => x.id.Equals(id));
        }
        public List<Tool> GetListToolsMock()
        {
            return toolsMock;
        }
    }
}