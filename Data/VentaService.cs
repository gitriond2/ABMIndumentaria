using IndumentariaIntimaWPF.Data;
using IndumentariaIntimaWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndumentariaIntimaWPF.Services
{
    public class VentaService
    {
        private readonly ApplicationDbContext _context;

        public VentaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Venta> ObtenerTodasLasVentas()
        {
            return _context.Ventas.ToList();
        }

        public Venta ObtenerVentaPorId(int idVenta)
        {
            return _context.Ventas.FirstOrDefault(v => v.ID_VENTA == idVenta);
        }

        public List<Venta> ObtenerVentasPorCliente(int clienteId)
        {
            return _context.Ventas.Where(v => v.CLIENTE == clienteId).ToList();
        }

        public List<VentasItem> ObtenerItemsDeVenta(int idVenta)
        {
            return _context.VentasItems.Where(vi => vi.IDVenta == idVenta).ToList();
        }

        public List<Venta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Ventas.Where(v => v.FECHA >= fechaInicio && v.FECHA <= fechaFin).ToList();
        }

        // Otros métodos de consulta según tus necesidades...
    }
}

