import { SocialNetwork } from './SocialNetwork';
import { Event } from './Event';

export interface Headline {
    headlineId: number; 
    name: string; 
    highLight: string; 
    imageURL: string; 
    phone: string; 
    email: string; 
    headlineEvents: Event[]
    socialNetworks: SocialNetwork[]

}

