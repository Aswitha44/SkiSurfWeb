import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { Brand } from 'src/app/shared/models/brand';
import { Type } from 'src/app/shared/models/type';
import { shopParams } from 'src/app/shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  @ViewChild('search') searchTerm?: ElementRef;
  products:Product[]=[];
  brands:Brand[]=[];
  types:Type[]=[];
  shopParams=new shopParams();
  sortOptions=[
    {name:'Alphabetical',value:'name'},
    {name:'Price: Low to High',value:'priceAsc'},
    {name:'Price: High to low',value:'priceDesc'}
  ];
  totalCount=0;

  constructor(private shopService:ShopService){}
  ngOnInit(): void {
   this.getProducts();
   this.getBrands();
   this.getTypes();

  }

  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe({
      next:response=>
      {this.products=response.data;
      this.shopParams.pageNumber=response.pageIndex;
      this.shopParams.pageSize=response.pageSize;    
        this.totalCount=response.count;
    },
      error: error=> console.log(error)
    })
  }

  getBrands(){
    this.shopService.getBrands().subscribe({
      next:response=>this.brands=[{id:0,name:'All'},...response],
      error: error=> console.log(error)
    })
  }

  getTypes(){
    this.shopService.getTypes().subscribe({
      next:response=>this.types=[{id:0,name:'All'},...response],
      error: error=> console.log(error)
    })
  }

  OnBrandSelected(brandId:number){
    this.shopParams.brandId=brandId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  OnTypeSelected(typeId:number){
    this.shopParams.typeId=typeId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  OnSortSelected(event:any){
    this.shopParams.sort= event.target.value;
    this.getProducts();
  }

  OnPageChanged(event:any){
  if(this.shopParams.pageNumber !==event){
  this.shopParams.pageNumber=event;
  this.getProducts();
}}

onSearch(){
  this.shopParams.search=this.searchTerm?.nativeElement.value;
  this.shopParams.pageNumber=1;
  this.getProducts();
}

onReset(){
 if(this.searchTerm) this.searchTerm.nativeElement.value = '';
 this.shopParams = new shopParams();
 this.getProducts();
}

}

