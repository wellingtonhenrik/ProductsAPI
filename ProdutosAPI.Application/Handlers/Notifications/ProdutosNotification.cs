using MediatR;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Handlers.Notifications;

/// <summary>
/// Modelo de dados da notificao de produtos
/// </summary>
public class ProdutosNotification : INotification
{
    public ActionNotification? Action { get; set; }
    public ProdutosDTO? ProdutosDTO { get; set; }
}

public enum ActionNotification
{
    Created,
    Update,
    Delete
}