﻿using ProductService.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace ProductService.Controllers
{
    public class SuppliersController : ODataController
    {
        ProductsContext db = new ProductsContext();

        private bool SupplierExists(int key)
        {
            return db.Suppliers.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        [EnableQuery]
        public IQueryable<Supplier> Get()
        {
            return db.Suppliers;
        }


        [EnableQuery]
        public SingleResult<Supplier> Get([FromODataUri] int key)
        {
            IQueryable<Supplier> result = db.Suppliers.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }


        public async Task<IHttpActionResult> Post(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();
            return Created(supplier);
        }

        // === Код для обоих методов обновления   PATCH  и  PUT 

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Supplier> supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Suppliers.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            supplier.Patch(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!SupplierExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Supplier update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }

            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!SupplierExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var supplier = await db.Suppliers.FindAsync(key);
            if (supplier == null)
            {
                return NotFound();
            }
            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Get /suppliers(1)/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }

        public async Task<IHttpActionResult> DeleteRef([FromODataUri] int key, [FromODataUri] string relatedKey, string navigationProperty)
        {
            var supplier = await db.Suppliers.SingleOrDefaultAsync(p => p.Id == key);
            if (supplier == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            switch (navigationProperty)
            {
                case "Products":
                    var productId = Convert.ToInt32(relatedKey);
                    var product = await db.Products.SingleOrDefaultAsync(p => p.Id == productId);

                    if (product == null)
                    {
                        return NotFound();
                    }
                    product.Supplier = null;
                    break;
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);

            }
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}