import { FormControl } from "@angular/forms";
import { ClienteXendereco } from "./cliente-xendereco";
import { ClienteXtelefone } from "./cliente-xtelefone";
import { Redesocial } from "./redesocial";

export class Cliente {

    id: number;
    nome: string;
    dataNascimento: Date;
    cpf: string;
    rg: string;
    clienteXEnderecos: ClienteXendereco[];
    clienteXTelefones: ClienteXtelefone[];
    redesSociais: Redesocial[];

}
