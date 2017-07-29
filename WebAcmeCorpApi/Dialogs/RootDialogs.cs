using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAcmeCorpApi.Dialogs
{
    public class RootDialogs
    {
        [LuisModel("cbefde26-ee58-4727-9adc-f873a3d657ae", "8acb43231a1841a79e120c370acfa26a")]
        [Serializable]
        public class RootDialog : LuisDialog<object>
        {
            public RootDialog() { }

            [LuisIntent("conversation.hello")]
            public async Task Hello(IDialogContext context, LuisResult result)
            {
                await context.PostAsync($"Olá! Sou o chatbot de venda de produtos da Acme Corp, escreva o que deseja saber.");
                context.Wait(MessageReceived);
            }

            [LuisIntent("conversation.about")]
            public async Task About(IDialogContext context, LuisResult result)
            {
                await context.PostAsync($"Sou um bot de Venda de produtos da Acme Corp, um assistente para sua consulta e compra de produtos para suas tramoias" +
                                        $"Fique a vontade para me perguntar os produtos que deseja buscar.");
                context.Wait(MessageReceived);
            }

            [LuisIntent("None")]
            public async Task None(IDialogContext context, LuisResult result)
            {
                await context.PostAsync($"Desculpe! Não entendi o que deseja ou sobre qual produto está falando. " +
                                        $"Tente ser mais específico, por exemplo: \"Quais armadilhas disponíveis\", \"Liste as proteções\" ou \"Desejo comprar armadilha\"");
                context.Wait(MessageReceived);
            }

            [LuisIntent("ComprarArmadilha")]
            public async Task Armadilha(IDialogContext context, LuisResult result)
            {
                await context.PostAsync($"Você quer comprar armadilhas? " +
                                        $"Temos diversas opções");
                context.Wait(MessageReceived);
            }

            [LuisIntent("ComprarProteção")]
            public async Task Defesa(IDialogContext context, LuisResult result)
            {
                await context.PostAsync($"Você quer comprar defesas? " +
                                        $"Temos diversas opções");
                context.Wait(MessageReceived);
            }

            /*[LuisIntent("moeda.listagem")]
            public async Task MoedaListagem(IDialogContext context, LuisResult result)
            {
                var service = new CotacaoMoeda();
                var list = await service.Listagem();

                await context.PostAsync("Moedas disponíveis para consulta:");

                foreach (var item in list)
                    await context.PostAsync($"{item.nome} ({item.moeda})");

                context.Wait(MessageReceived);
            }

            [LuisIntent("moeda.cotacao")]
            public async Task MoedaCotacao(IDialogContext context, LuisResult result)
            {
                var service = new CotacaoMoeda();
                var moeda = result.Entities.FirstOrDefault(x => x.Type.Equals("Moeda"));
                await context.PostAsync("Cotações:");

                var list = await service.Cotacao(moeda?.Entity ?? string.Empty);

                foreach (var cotacao in list)
                {
                    var dataAtualizacao = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(cotacao.ultima_consulta).ToLocalTime();
                    await context.PostAsync($"{cotacao.nome}: R$ {cotacao.valor.ToString("N4")}");
                    await context.PostAsync($"Data: {dataAtualizacao} | Fonte: {cotacao.fonte}");
                }
                context.Wait(MessageReceived);
            }*/
        }
    }
}