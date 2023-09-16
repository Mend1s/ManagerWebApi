import { Endereco } from './../../features/cliente/models/endereco';
import { TipoCliente } from './../../features/cliente/models/tipoCliente';
import { ClienteService } from 'src/app/service/cliente.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Client } from 'src/app/features/cliente/models/client';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-client',
  templateUrl: './new-client.component.html',
  styleUrls: ['./new-client.component.scss']
})
export class NewClientComponent implements OnInit {

  id!: string;
  client!: Client;
  checkedClient!: boolean;
  formsNewClient!: FormGroup;
  rota!: string;

  constructor(
    private clientService: ClienteService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.createdFormsClient();
    this.asEditorCreate();
  }

  createdFormsClient() {
    this.formsNewClient = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.max(45)]],
      documento: ['', [Validators.required, Validators.minLength(11), Validators.max(14)]],
      tipoCliente: [''],
      endereco: this.formBuilder.group({
        logradouro: [''],
        numero: [''],
        complemento: [''],
        cep: [''],
        bairro: [''],
        cidade: [''],
        estado: [''],
      }),
      email: ['', [Validators.required, Validators.email, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      dataNascimento: [''],
      sexo: [''],
      observacoes: [''],
      dataCadastro: [''],
      telefone: ['']
    })
  }

  asEditorCreate() {
    this.rota = this.activatedRoute.snapshot.url[0].path;

    if (this.rota === 'edit-client') {
      this.getIdByRoute();
      this.getClientbyId();
    } else { }
  }

  getIdByRoute() {
    this.id = this.activatedRoute.snapshot.url[1].path;
  }

  getClientbyId() {
    this.clientService.getClientById(this.id).subscribe(client => {
      this.client = client;
      this.formsNewClient.controls['nome'].setValue(this.client.nome);
      this.formsNewClient.controls['documento'].setValue(this.client.documento);
      this.formsNewClient.controls['tipoCliente'].setValue(this.client.tipoCliente);
      this.formsNewClient.controls['endereco.logradouro'].setValue(this.client.endereco.logradouro);
      this.formsNewClient.controls['endereco.numero'].setValue(this.client.endereco.numero);
      this.formsNewClient.controls['endereco.complemento'].setValue(this.client.endereco.complemento);
      this.formsNewClient.controls['endereco.cep'].setValue(this.client.endereco.cep);
      this.formsNewClient.controls['endereco.bairro'].setValue(this.client.endereco.bairro);
      this.formsNewClient.controls['endereco.cidade'].setValue(this.client.endereco.cidade);
      this.formsNewClient.controls['endereco.estado'].setValue(this.client.endereco.estado);
      this.formsNewClient.controls['email'].setValue(this.client.email);
      this.checkedClient = true;
    })
  }

  saveForms() {
    const clientSave: Client = {
      id: (this.id),
      nome: this.formsNewClient.controls['name'].value,
      documento: this.formsNewClient.controls['documento'].value,
      tipoCliente: this.formsNewClient.controls['tipoCliente'].value,
      endereco: {
        logradouro: this.formsNewClient.controls['endereco.logradouro'].value,
        numero: this.formsNewClient.controls['endereco.numero'].value,
        complemento: this.formsNewClient.controls['endereco.complemento'].value,
        cep: this.formsNewClient.controls['endereco.cep'].value,
        bairro: this.formsNewClient.controls['endereco.bairro'].value,
        cidade: this.formsNewClient.controls['endereco.cidade'].value,
        estado: this.formsNewClient.controls['endereco.estado'].value,
        clienteId: 0,
      },
      email: this.formsNewClient.controls['email'].value,
      dataNascimento: this.formsNewClient.controls['dataNascimento'].value,
      sexo: this.formsNewClient.controls['sexo'].value,
      observacoes: this.formsNewClient.controls['observacoes'].value,
      dataCadastro: this.formsNewClient.controls['dataCadastro'].value,
      telefone: this.formsNewClient.controls['telefone'].value,
    }

    if (!this.checkedClient) {
      this.createdClient(clientSave);
    } else {
      this.updateClient(clientSave);
    }
  }

  createdClient(clientSave: Client) {
    this.clientService.postClient(clientSave).subscribe(response => {
      this.router.navigate(['cliente', 'list-client']);
    })
  }

  updateClient(clientSave: Client) {
    this.clientService.putClient(clientSave).subscribe(response => {
      this.router.navigate(['cliente', 'list-client']);
    })
  }
}
