using PicPay.DTO_s;
using PicPay.Entidades;

namespace PicPay.Mappers;

public class CarteiraMapper
{
    public ResponseCarteiraDto CarteiraToResponseDto(Carteira carteira)
    {
        if (carteira == null)
        {
            return null; 
            
        }
        ResponseCarteiraDto response = new ResponseCarteiraDto(carteira.TitularId, carteira.Titular.Nome, carteira.Saldo);

        return response;
    }
}