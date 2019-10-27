using credito.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace credito.Controllers
{
    [Route("api")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        [Route("v1/credito")]
        [HttpPost]
        public CreditoView Post([FromBody]SolicitacaoCreditoView solicitacaoCredito)
        {
            var _repository = new Servico.Credito();
            return _repository.ValidarCredito(solicitacaoCredito);
        }
    }
}