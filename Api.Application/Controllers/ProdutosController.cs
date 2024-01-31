using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Produtos;
using Api.Domain.Interfaces.Services.Produtos;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        public IProdutosService _service { get; set; }
        public ProdutosController(IProdutosService service)
        {
            _service = service;
        }
     
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RecuperarTodos(int numeroPagina, int quantidadeRegistros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {   
                return Ok(await _service.GetAll(numeroPagina, quantidadeRegistros));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Recuperar(int id)
        {
            var erro = new Erro();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);

                if (result == null)
                {
                    erro.Mensagem = "Nenhum registro encontrato";
                    return BadRequest(erro);
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Inserir([FromBody] ProdutosDtoCreate produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           
            try
            {
                var erro = new Erro();
                //Formatar dataFabricacao
                string formato = "yyyy-MM-dd";
                DateTime dataFabricacaoFormatado = DateTime.ParseExact(produto.DataFabricacao, formato, CultureInfo.InvariantCulture);
                DateTime dataValidadeFormatado = DateTime.ParseExact(produto.DataValidade, formato, CultureInfo.InvariantCulture);

                if (dataFabricacaoFormatado >= dataValidadeFormatado) 
                {
                    erro.Mensagem = "O valor da data de fabricação não pode ser maior que a data de validade";
                    return BadRequest(erro);
                }                    

                //Formatar Cnpj
                produto.CnpjFornecedor = produto.CnpjFornecedor.Replace(".", "").Replace("-", "").Replace("/", "");
         
                //Realiza o Post
                var result = await _service.Post(produto);

                //Validação do resultado
                if (result != null)
                {            
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                }
                else
                {
                    erro.Mensagem = "Ocorreu um erro ao salvar os registros.";
                    return BadRequest(erro);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

      
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Editar([FromBody] ProdutosDtoUpdate produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var erro = new Erro();
                //Formatar dataFabricacao
                string formato = "yyyy-MM-dd";
                DateTime dataFabricacaoFormatado = DateTime.ParseExact(produto.DataFabricacao, formato, CultureInfo.InvariantCulture);
                DateTime dataValidadeFormatado = DateTime.ParseExact(produto.DataValidade, formato, CultureInfo.InvariantCulture);

                if (dataFabricacaoFormatado >= dataValidadeFormatado)
                {
                    erro.Mensagem = "O valor da data de fabricação não pode ser maior que a data de validade";
                    return BadRequest(erro);
                }

                //Formatar Cnpj
                produto.CnpjFornecedor = produto.CnpjFornecedor.Replace(".", "").Replace("-", "").Replace("/", "");

                var result = await _service.Put(produto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    erro.Mensagem = "Número de Id não encontrado";
                    return BadRequest(erro);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

      
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InativarProduto([FromBody] ProdutosDtoUpdate produto)
        {
            var erro = new Erro();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (produto.Situacao.Equals("Inativo"))
                {
                    return Ok(await _service.Put(produto));
                }

                erro.Mensagem = "Produto não pode ser inativado, pois o campo Situação ainda está como Ativo";
                return BadRequest(erro);

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
