using Contatos.Application.DTOs;
using Contatos.Application.UseCases.Contatos;
using Contatos.Message.Messages;
using MassTransit;

namespace Contatos.Worker.Consumers
{
    public class UpdateContatoConsumer : IConsumer<UpdateContatoMessage>
    {
        private readonly UpdateContato _updateContato;

        public UpdateContatoConsumer(UpdateContato updateContato)
            => _updateContato = updateContato;

        public async Task Consume(ConsumeContext<UpdateContatoMessage> context)
        {
            try
            {
                var input = new UpdateContatoInput
                {
                    Id = context.Message.Id,
                    Nome = context.Message.Nome,
                    Email = context.Message.Email,
                    Telefone = context.Message.Telefone
                };
                await _updateContato.UpdateContatoAsync(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex);
                throw;
            }
        }
    }
}
