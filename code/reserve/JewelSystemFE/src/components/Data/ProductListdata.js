import Product1 from '../../assets/images/product/product-1.jpg';
import Product2 from '../../assets/images/product/product-2.jpg';
import Product3 from '../../assets/images/product/product-3.jpg';
import Product4 from '../../assets/images/product/product-4.jpg';
import Product5 from '../../assets/images/product/product-5.jpg';
import Product6 from '../../assets/images/product/product-6.jpg';
import axios from "../../api/axios";


function getProduct() {
   let response = [];
   const get = async () => {
     try {
       response = await axios.get("/product");
       console.log(JSON.stringify(response.data));
     } catch (err) {
       console.error(err);
     }
   };
   get();
   return response.data;
 };

// export default getProduct
export const ProductListdata=[
   {
     "productId": "9b0b750c-bc7c-4c20-8515-a0e2bcd28c15",
     "productCode": "P005",
     "productName": "Topaz Pendant",
     "productImages": Product1,
     "productQuantity": 20,
     "productType": "Pendant",
     "productWeight": 10,
     "productWarranty": 6,
     "markupRate": 1.1,
     "gemId": "5",
     "gem": null,
     "gemWeight": 2.5,
     "goldId": "5",
     "gold": null,
     "goldWeight": 7.5,
     "laborCost": 90,
     "createdAt": "2024-06-09T23:46:17.5381549"
   },
   {
     "productId": "9a4be737-cb37-43e5-a317-e81c495e0af7",
     "productCode": "P002",
     "productName": "Sapphire Ring",
     "productImages": Product2,
     "productQuantity": 5,
     "productType": "Ring",
     "productWeight": 20,
     "productWarranty": 24,
     "markupRate": 1.5,
     "gemId": "2",
     "gem": null,
     "gemWeight": 2,
     "goldId": "2",
     "gold": null,
     "goldWeight": 18,
     "laborCost": 100,
     "createdAt": "2024-06-09T23:46:17.5381529"
   },
   {
     "productId": "9945b594-2bc1-4e76-beb9-990fe18d4ac5",
     "productCode": "P003",
     "productName": "Emerald Bracelet",
     "productImages": Product3,
     "productQuantity": 8,
     "productType": "Bracelet",
     "productWeight": 30,
     "productWarranty": 18,
     "markupRate": 1.3,
     "gemId": "3",
     "gem": null,
     "gemWeight": 3,
     "goldId": "3",
     "gold": null,
     "goldWeight": 27,
     "laborCost": 150,
     "createdAt": "2024-06-09T23:46:17.5381535"
   },
   {
     "productId": "5ef80e39-91d5-48bd-ba77-df4de5961262",
     "productCode": "P006",
     "productName": "Ruby Bracelet",
     "productImages": Product4,
     "productQuantity": 7,
     "productType": "Bracelet",
     "productWeight": 25,
     "productWarranty": 12,
     "markupRate": 1.2,
     "gemId": "1",
     "gem": null,
     "gemWeight": 4,
     "goldId": "2",
     "gold": null,
     "goldWeight": 21,
     "laborCost": 130,
     "createdAt": "2024-06-09T23:46:17.5381567"
   },
   {
     "productId": "178058ea-7e48-450b-a710-7eb304d57d32",
     "productCode": "P001",
     "productName": "Ruby Necklace",
     "productImages": Product5,
     "productQuantity": 10,
     "productType": "Necklace",
     "productWeight": 50,
     "productWarranty": 12,
     "markupRate": 1.2,
     "gemId": "1",
     "gem": null,
     "gemWeight": 5,
     "goldId": "1",
     "gold": null,
     "goldWeight": 45,
     "laborCost": 200,
     "createdAt": "2024-06-09T23:46:17.538152"
   },
   {
     "productId": "08ea4bc8-aaae-4292-b7f4-933608a0266a",
     "productCode": "P004",
     "productName": "Diamond Earrings",
     "productImages": Product6,
     "productQuantity": 12,
     "productType": "Earrings",
     "productWeight": 15,
     "productWarranty": 24,
     "markupRate": 1.7,
     "gemId": "4",
     "gem": null,
     "gemWeight": 1.5,
     "goldId": "4",
     "gold": null,
     "goldWeight": 13.5,
     "laborCost": 180,
     "createdAt": "2024-06-09T23:46:17.5381542"
   }
 ]