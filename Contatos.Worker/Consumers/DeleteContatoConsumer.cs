using Contatos.Application.UseCases.Contatos;
using Contatos.Message.Messages;
using MassTransit;

namespace Contatos.Worker.Consumers
{
    public class DeleteContatoConsumer : IConsumer<DeleteContatoMessage>
    {
        private readonly DeleteContato _deleteContato;

        public DeleteContatoConsumer(DeleteContato deleteContato)
            => _deleteContato = deleteContato;
        public async Task Consume(ConsumeContext<DeleteContatoMessage> context)
        {
            try
            {
                await _deleteContato.DeleteContatoAsync(context.Message.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex);
                throw;
            }
        }
    }
}
