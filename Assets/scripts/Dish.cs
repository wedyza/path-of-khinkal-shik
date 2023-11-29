using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDish
{
    public List<Product> ProductsIn { get; set; }
    public bool IsCooked { get; set; }
    public void AddProduct(Product product);
}
    