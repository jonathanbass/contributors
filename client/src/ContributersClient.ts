import axios from 'axios';

export interface IContributer {
    name: string;
    email: string;
    date: string;
}

interface IContributersResponse {
    contributers: IContributer[];
}

export class ContributersClient {
    static async getContributers(owner: string, repository: string) {
        const response = await axios.get<IContributersResponse>(`https://localhost:5000/api/v1/${owner}/${repository}/contributers`);
        return response.data.contributers;
    }
}