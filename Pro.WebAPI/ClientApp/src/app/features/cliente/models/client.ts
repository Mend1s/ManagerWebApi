import { Endereco } from "./endereco";
import { TipoCliente } from "./tipoCliente";

export interface Client {
  id: string;
  nome: string;
  documento: string;
  tipoCliente: TipoCliente;
  enderecoId?: number;
  endereco: Endereco;
  telefone: string;
  email: string;
  dataNascimento: Date;
  sexo: string;
  observacoes: string;
  dataCadastro: Date;
}
