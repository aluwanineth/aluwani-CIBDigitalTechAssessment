import { Entry } from 'src/app/phoneBook/models/responses/Entry';

export interface PhoneBook {
    id: number;
    phoneBookName: string;
    entry: Entry[];
}
