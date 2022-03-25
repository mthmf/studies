using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {

        [Fact]
        public void TestaConexaoContextoBanco()
        {
            // arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível conectar na base de dados");
            }

            Assert.True(conectado);

        }
    }
}
