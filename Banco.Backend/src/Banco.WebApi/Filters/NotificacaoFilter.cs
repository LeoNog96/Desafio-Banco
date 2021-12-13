using Banco.Application.Notificacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.WebApi.Filters
{
    public class NotificacaoFilter : IAsyncResultFilter
    {
        private readonly NotificacaoContext _notificacoesContext;

        public NotificacaoFilter(NotificacaoContext notificacoesContext)
        {
            _notificacoesContext = notificacoesContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificacoesContext.ExisteNotificacoes)
            {
                context.HttpContext.Response.StatusCode = _notificacoesContext.CodigoStatus;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(new NotificacaoResponse("Falha na Operação", _notificacoesContext.Notificacoes));
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }
            await next();
        }
    }
}
