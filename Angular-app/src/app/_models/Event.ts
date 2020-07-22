import { Release } from './Release';
import { SocialNetwork } from './SocialNetwork';
import { Headline } from './Headline';

export interface Event {
    eventId: number;
    location: string; 
    eventDate?: Date; 
    type: string; 
    name: string;
    capacity: number 
    imageURL: string 
    phone: string;
    email: string;
    releases: Release[]
    socialNetworks: SocialNetwork[]
    headlineEvents: Headline[]
}
