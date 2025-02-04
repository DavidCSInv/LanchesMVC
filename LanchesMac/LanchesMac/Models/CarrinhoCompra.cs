﻿using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public static CarrinhoCompra GetCarrinhoCompra(IServiceProvider services)
        {
            //definindo uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId
                && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItems.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }
        public void RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId
                && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                }
                else
                {
                    _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
        }
        public List<CarrinhoCompraItem> GetCarrinhoCompras() => CarrinhoCompraItems ??  
                                                                (CarrinhoCompraItems = _context.CarrinhoCompraItems
                                                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                                                .Include(s => s.Lanche)
                                                                .ToList());  
        public void LimparCarrinho()
        {
            var carrinhoCompraItens = _context.CarrinhoCompraItems
                                        .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItems.RemoveRange();
            _context.SaveChanges();
        }
        public decimal getCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItems
                        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();
            return total;
        }
    }

}