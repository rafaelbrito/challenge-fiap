using Contatos.Application.DTOs;
using Contatos.Application.UseCases.Contatos;
using Contatos.Message.Messages;
using MassTransit;

namespace Contatos.Worker.Consumers
{
    public class CreateContatoConsumer : IConsumer<CreateContatoMessage>
    {
        private readonly CreateContato _createContato;

        public CreateContatoConsumer(CreateContato createContato)
            => _createContato = createContato;

        public async Task Consume(ConsumeContext<CreateContatoMessage> context)
        {
            try
            {
                var input = new CreateContatoInput
                {
                    Nome = context.Message.Nome,
                    Email = context.Message.Email,
                    Telefone = context.Message.Telefone
                };
                await _createContato.CreateAsync(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro:" + ex);
                throw;
            }
        }
    }
}
