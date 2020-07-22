export interface Release {
    releaseId: number;  
    name: string;  
    price: number;  
    dateMin?: Date;
    dateMax?: Date;
    quantity: number;  
    eventId: number;
}
