using System.Diagnostics;
using MediatR;
using ProdutosAPI.Application.Interfaces.Stores;

namespace ProdutosAPI.Application.Handlers.Notifications;

/// <summary>
/// Componente para 'escutar' o resultado do processamento dos RequestHandlers
/// e executar as operações no banco de cache
/// </summary>
public class ProdutosNotificationHandler : INotificationHandler<ProdutosNotification>
{
    private readonly IProdutosStore _produtosStore;

    public ProdutosNotificationHandler(IProdutosStore produtosStore)
    {
        _produtosStore = produtosStore;
    }

    /// <summary>
    /// Metodo para ouvir e processar as notificações no banco de dados de leitura 
    /// Chamado apos um REQUEST HANDLE executar o PUBLISH NOTIFICATION
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task Handle(ProdutosNotification notification, CancellationToken cancellationToken)
    {
        //verificando o tipo de notificação recebida 
        switch (notification.Action)
        {
            case ActionNotification.Created: _produtosStore.Add(notification.ProdutosDTO); break;
            case ActionNotification.Update: _produtosStore.Update(notification.ProdutosDTO); break;
            case ActionNotification.Delete: _produtosStore.Delete(notification.ProdutosDTO.id); break;
        } 

        return Task.CompletedTask;
    }
}