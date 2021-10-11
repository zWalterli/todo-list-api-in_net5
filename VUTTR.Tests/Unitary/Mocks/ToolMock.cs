using System.Collections.Generic;
using System.Linq;
using VUTTR.Domain.Models;
using VUTTR.Domain.ViewModels;

namespace VUTTR.Tests.Unitary.Mocks
{
    public class ToolMock
    {
        private readonly List<ToolViewModel> toolsViewModelMock = new List<ToolViewModel>{
            new ToolViewModel {
                id = 1,
                title = "Descrição de Teste",
                description = "Descrição de Teste",
                link = "www.descricao.com.br",
                Tags = new List<TagViewModel> {
                    new TagViewModel {
                        description = "descrição"
                    },
                    new TagViewModel {
                        description = "teste"
                    }
                }
            },
            new ToolViewModel {
                id = 2,
                title = "Teste de Descrição",
                description = "Teste de Descrição",
                link = "www.Teste.com.br",
                Tags = new List<TagViewModel> {
                    new TagViewModel {
                        description = "outro"
                    },
                    new TagViewModel {
                        description = "teste"
                    }
                }
            }
        };
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
        public ToolViewModel GetToolViewModelMock(int id)
        {
            return toolsViewModelMock.FirstOrDefault(x => x.id.Equals(id));
        }
        public List<ToolViewModel> GetListToolsViewModelMock()
        {
            return toolsViewModelMock;
        }
    }
}