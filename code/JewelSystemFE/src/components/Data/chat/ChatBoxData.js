import Avatar2 from '../../../assets/images/xs/avatar2.svg'
import A1 from '../../../assets/images/gallery/1.jpg';

export const ChatBoxData=[
    {
       image:Avatar2,
       type:'received',
       time:'10:10 AM, Today',
       message:'Hi Aiden, how are you?'
    },
    {
       
        type:'send',
        time:'10:12 AM, Today',
        message:'Fine'
     },
     {
         image:Avatar2,
         type:'received',
         time:' 10:10 AM, Today',
         message:'Product Stoke available'
     },
     {
         image:Avatar2,
         type:'received',
         time:' 10:10 AM, Today',
         message:'Yes, and also new stoke On Way'
     },
     {
         
         type:'send',
         time:'10:12 AM, Today',
         message:'ok,Lets check stoke and sent me product pic'
     },
     {
         image:Avatar2,
         type:'received',
         time:'10:10 AM, Today',
         message:'Please find attached images',
         images:[
            A1,
            A1
        ],
     },
     {
        
         type:'send',
         time:'10:12 AM, Today',
         message:'Okay, will check and let you know.'
     }
    
     
]
