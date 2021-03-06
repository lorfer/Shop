﻿using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Shop.Web.Data.Entities
{
    public class Product:IEntity
    {
		public int Id { get; set; }

		//DataNotacion
		[MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} de tamaño de longitud.")]
		[Required]
		public string Name { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		//Descorados: Para cambiar el diseño 
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
			
		public decimal Price { get; set; }
		//Display: Change the parch
		[Display(Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(Name = "Last Purchase")]
		public DateTime? LastPurchase { get; set; }
		//Acmite null ?
		[Display(Name = "Last Sale")]
		public DateTime? LastSale { get; set; }

		[Display(Name = "Is Availabe?")]
		public bool IsAvailabe { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		
		public double Stock { get; set; }

		public User User { get; set; }

		public string ImageFullPath { 
			
			get
			{
				if (string.IsNullOrEmpty(this.ImageUrl))
				{
					return null;

				}
				//string interpolation
				return $"https://shopeweblorfe.azurewebsites.net{this.ImageUrl.Substring(1)}" ;

				//return "https://shoplorfe.azurewebsites.net " + this.ImageUrl.Substring(1);
			}
			
		}

	}
}
