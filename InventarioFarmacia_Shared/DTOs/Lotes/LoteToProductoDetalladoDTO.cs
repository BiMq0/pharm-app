using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioFarmacia_Domain.Models;
using InventarioFarmacia_Shared.DTOs.Products.Individual;

namespace InventarioFarmacia_Shared.DTOs.Lotes
{
    public class LoteToProductoDetalladoDTO
    {
        public int Id { get; set; }
        public int Id_Producto { get; set; }
        public DateOnly Fecha_Vencimiento { get; set; }
        public string Nro_Lote { get; set; } = null!;
        public ICollection<ProductoIndividualToLoteDTO>? ProductosIndividuales { get; set; }

        public int CantidadProductos { get; set; }

        public int CantidadProductosDisponibles { get; set; }
        public IEnumerable<ProductoIndividualToLoteDTO> ProductosDisponibles { get; set; } = Enumerable.Empty<ProductoIndividualToLoteDTO>();

        public int CantidadProductosPorVencer { get; set; }
        public IEnumerable<ProductoIndividualToLoteDTO> ProductosPorVencer { get; set; } = Enumerable.Empty<ProductoIndividualToLoteDTO>();

        public int CantidadProductosVendidos { get; set; }
        public IEnumerable<ProductoIndividualToLoteDTO> ProductosVendidos { get; set; } = Enumerable.Empty<ProductoIndividualToLoteDTO>();

        public int CantidadProductosVencidos { get; set; }
        public IEnumerable<ProductoIndividualToLoteDTO> ProductosVencidos { get; set; } = Enumerable.Empty<ProductoIndividualToLoteDTO>();

        public LoteToProductoDetalladoDTO(Lote lote)
        {
            Id = lote.Id;
            Id_Producto = lote.Id_Producto;
            Fecha_Vencimiento = lote.Fecha_Vencimiento;
            Nro_Lote = lote.Nro_Lote!;
            CantidadProductos = lote.CantidadProductos;
            ProductosIndividuales = lote.ProductosIndividuales?.Select(pi => new ProductoIndividualToLoteDTO(pi)).ToList();
            CantidadProductosDisponibles = lote.CantidadProductosDisponibles;
            ProductosDisponibles = lote.ProductosDisponibles.Select(pi => new ProductoIndividualToLoteDTO(pi)).ToList();
            CantidadProductosPorVencer = lote.CantidadProductosPorVencer;
            ProductosPorVencer = lote.ProductosPorVencer.Select(pi => new ProductoIndividualToLoteDTO(pi)).ToList();
            CantidadProductosVendidos = lote.CantidadProductosVendidos;
            ProductosVendidos = lote.ProductosVendidos.Select(pi => new ProductoIndividualToLoteDTO(pi)).ToList();
            CantidadProductosVencidos = lote.CantidadProductosVencidos;
            ProductosVencidos = lote.ProductosVencidos.Select(pi => new ProductoIndividualToLoteDTO(pi)).ToList();
        }

        public LoteToProductoDetalladoDTO()
        {

        }
    }
}