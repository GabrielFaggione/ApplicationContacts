import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { EstadosService } from 'src/app/services/estados.service';
import { TiposService } from 'src/app/services/tipos.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { Cliente } from 'src/app/models/cliente';
import { takeUntil } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { TipoClienteXEndereco } from 'src/app/models/tipo-cliente-xendereco';
import { TipoClienteXtelefone } from 'src/app/models/tipo-cliente-xtelefone';
import { TipoRedeSocial } from 'src/app/models/tipo-rede-social';
import { Estado } from 'src/app/models/estado';
import { Cidade } from 'src/app/models/cidade';
import { Endereco } from 'src/app/models/endereco';
import { ClienteXendereco } from 'src/app/models/cliente-xendereco';
import { ClienteXtelefone } from 'src/app/models/cliente-xtelefone';
import { Telefone } from 'src/app/models/telefone';
import { Redesocial } from 'src/app/models/redesocial';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.css']
})
export class EditorComponent implements OnInit {

  private clienteId: string;
  private clienteSelecionado : Cliente;
  private tiposEnderecos: TipoClienteXEndereco[];
  private tiposTelefones: TipoClienteXtelefone[];
  private tiposRedeSociais: TipoRedeSocial[];
  private estados: Estado[];
  private cidades: Cidade[];
  private unsubscriber = new Subject();
  private dataNascimentoISO : FormControl = new FormControl();

  public cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];
  public rgMask = [/\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/];
  public cepMask = [/\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/];

  constructor(
    private DashboardService: DashboardService,
    private TiposService: TiposService,
    private EstadoService: EstadosService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) 
  { }



  ngOnInit() {

    this.carregarTiposRedeSocial();
    this.carregarTiposEnderecos();
    this.carregarTiposTelefones();
    this.carregarEstados();
    this.carregarCidades();

    this.clienteId = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.clienteId == undefined) { 
      this.clienteId = '0';
      this.clienteSelecionado = new Cliente();
      this.clienteSelecionado.id = 0;
      this.clienteSelecionado.clienteXEnderecos = [];
      this.clienteSelecionado.clienteXTelefones = [];
      this.clienteSelecionado.redesSociais = [];
    }
    else {
      this.carregarInformacoesCliente();
    }
    console.log(this.clienteSelecionado);
  }

  carregarInformacoesCliente(){
    this.DashboardService.getClienteInfo(this.clienteId)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((cliente: Cliente) => {
        this.toastr.success('Informações carregadas');
        this.clienteSelecionado = cliente;
        console.log(this.clienteSelecionado);

        this.dataNascimentoISO = new FormControl(new Date(this.clienteSelecionado.dataNascimento.toString()).toISOString());
      },
      (error: any) => {
        console.error(error);
        this.toastr.success('Erro ao carregar informações do cliente');
      }
    );
  }

  carregarTiposEnderecos(){
    this.TiposService.getTipoClienteXEndereco()
      //.pipe(takeUntil(this.unsubscriber))
      .subscribe((resultado: TipoClienteXEndereco[]) => {
        this.tiposEnderecos = resultado;
      },
      (error: any) => {
        console.log(error);
      });
  }
  carregarTiposTelefones(){
    this.TiposService.getTipoClienteXEndereco()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((resultado: TipoClienteXtelefone[]) => {
        this.tiposTelefones = resultado;
      },
      (error: any) => {
        console.log(error);
      });
  }
  carregarTiposRedeSocial(){
    this.TiposService.getTipoRedeSocial()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((resultado: TipoRedeSocial[]) => {
        this.tiposRedeSociais = resultado;
        if (this.clienteSelecionado.redesSociais.length == 0){
          for (let i = 0; i < 4; i++){
            var redeSocial = new Redesocial();
            console.log(this.tiposRedeSociais[i]);
            redeSocial.tipoRedeSocial = this.tiposRedeSociais[i];
            this.clienteSelecionado.redesSociais.push(redeSocial);
          }
        }
      },
      (error: any) => {
        console.log(error);
      });
  }
  carregarEstados(){
    this.EstadoService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((resultado: Estado[]) => {
        this.estados = resultado;
      },
      (error: any) => {
        console.log(error);
      });
  }
  carregarCidades(){
    this.EstadoService.getCidades()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((resultado: Cidade[]) => {
        this.cidades = resultado;
      },
      (error: any) => {
        console.log(error);
      });
  }

  salvarInformacoes(){
    if (this.clienteId == '0'){
      this.DashboardService.post(this.clienteSelecionado)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe((resultado: number) => {
          this.toastr.success("Cliente salvo com sucesso");
          this.router.navigate(['/editor', resultado]);
        },
        (error:any) => {
          this.toastr.error("Erro ao salvar cliente");
        });
    }
    else
    {
    this.DashboardService.put(this.clienteSelecionado)
      .subscribe(
        (sucess : Cliente) => {
          this.toastr.success("Cliente salvo com sucesso");
          this.router.navigate(['/editor', sucess.id]);
        },
        (error: any) => {
          console.log(error);
          this.toastr.error("Erro ao salvar cliente");
        }
      )
    }
  }

  filtro(itemList: Cidade[], estadoId : number): Cidade[] {
    let result: Cidade[] = [];
    for (let cidade of itemList){
      if (cidade.estadoId == estadoId){
        result.push(cidade);
      }
    }
    return result;
  }

  adicionarEndereco(){
    let cxe = new ClienteXendereco();
    cxe.endereco = new Endereco();
    cxe.endereco.cidade = new Cidade();
    cxe.endereco.cidade.estado = new Estado();
    cxe.tipoClienteXEndereco = new TipoClienteXEndereco();
    this.clienteSelecionado.clienteXEnderecos.push(cxe);
  }

  adicionarTelefone(){
    let cxt = new ClienteXtelefone();
    cxt.telefone = new Telefone();
    cxt.tipoClienteXTelefone = new TipoClienteXtelefone();
    this.clienteSelecionado.clienteXTelefones.push(cxt);
  }

}
