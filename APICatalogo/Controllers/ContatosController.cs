using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ContatosController (AppDbContext contexto)
        {
            _context = contexto;
        }

        // api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Contato>> Get()
        {
            //AsNoTracking desabilita o gerenciamento do estado das entidades
            //so deve ser usado em consultas sem alteração
            //return _context.Produtos.AsNoTracking().ToList();
            try
            {
                return _context.Contatos.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Erro ao tentar obter os contatos do banco de dados");
            }
        }
        
                // api/produtos/1
                [HttpGet("{id}", Name = "ObterContato")]
                public ActionResult<Contato> Get(int id)
                {
                    //AsNoTracking desabilita o gerenciamento do estado das entidades
                    //so deve ser usado em consultas sem alteração
                    //var produto = _context.Produtos.AsNoTracking()
                    //    .FirstOrDefault(p => p.ProdutoId == id);
                    try
                    {
                        var contato = _context.Contatos.FirstOrDefault(p => p.ContatoId == id);

                        if (contato == null)
                        {
                            return NotFound($"O contato com id={id} não foi encontrada");
                        }
                        return contato;
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                             $"Erro ao tentar obter dados do contato com id = {id}");
                    }
                }

                //  api/produtos
                [HttpPost]
                public ActionResult Post([FromBody]Contato contato)
                {
                    //a validação do ModelState é feito automaticamente
                    //quando aplicamos o atributo [ApiController]
                    //if (!ModelState.IsValid)
                    //{
                    //    return BadRequest(ModelState);
                    //}
                    try
                    {
                        _context.Contatos.Add(contato);
                        _context.SaveChanges();

                        return new CreatedAtRouteResult("ObterContato",
                            new { id = contato.ContatoId }, contato);
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                           "Erro ao criar um novo contato");
                    }

                }

                // api/produtos/1
                [HttpPut("{id}")]
                public ActionResult Put(int id, [FromBody] Contato contato)
                {
                    //a validação do ModelState é feito automaticamente
                    //quando aplicamos o atributo [ApiController]
                    //if(!ModelState.IsValid)
                    //{
                    //    return BadRequest(ModelState);
                    //}
                    try
                    {
                        if (id != contato.ContatoId)
                        {
                            return BadRequest($"Não foi possível atualizar o contato com id={id}");
                        }

                        _context.Entry(contato).State = EntityState.Modified;
                        _context.SaveChanges();
                        return Ok($"Contato com id={id} atualizado com sucesso");
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                               $"Erro ao atualizar dados do contato com id =  {id}");
                    }
                }

                //  api/produtos/1
                [HttpDelete("{id}")]
                public ActionResult<Contato> Delete(int id)
                {
                    // Usar o método Find é uma opção para localizar 
                    // o produto pelo id (não suporta AsNoTracking)
                    //var produto = _context.Produtos.Find(id);

                    try
                    {
                        var contato = _context.Contatos.FirstOrDefault(p => p.ContatoId == id);

                        if (contato == null)
                        {
                            return NotFound("O contato com id={id} não foi encontrado");
                        }

                        _context.Contatos.Remove(contato);
                        _context.SaveChanges();
                        return contato;
                    }
                    catch (Exception)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                                               $"Erro ao excluir o produto de id = {id}");
                    }
                }
    }
}