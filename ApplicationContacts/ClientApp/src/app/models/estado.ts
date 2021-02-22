import { Cidade } from "./cidade";

export class Estado {

    id: number;
    nome: string;
    uf: string;

}

export class EstadoComCidades {

    id: number;
    nome: string;
    uf: string;
    cidades: Cidade[];
}