import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/cliente';
import { DashboardService } from 'src/app/services/dashboard.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { PaginatedResult, Pagination } from 'src/app/models/pagination';

@Component({
  selector: 'app-dashboarb',
  templateUrl: './dashboarb.component.html',
  styleUrls: ['./dashboarb.component.css']
})
export class DashboarbComponent implements OnInit {

  displayedColumns: string[] = ['Nome', 'Data Nascimento', 'CPF', 'RG', 'actions'];
  public clienteSelecionado: Cliente;
  public clientes: Cliente[];
  private pagination: Pagination;

  private unsubscriber = new Subject();

  constructor(
    private DashboardService: DashboardService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private fb: FormBuilder,
    private dialog: MatDialog,
    private router: Router
  ) { 

  }

  ngOnInit() {
    this.pagination = { currentPage: 1, pageSize: 4, filtro: "" } as Pagination;
    this.carregarClientes();
  }

  carregarClientes() {
    this.spinner.show();
    if (this.pagination.filtro == undefined) this.pagination.filtro = "";
    this.DashboardService.getByPagination(this.pagination.currentPage, this.pagination.pageSize, this.pagination.filtro)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((clientes: PaginatedResult<Cliente[]>) => {
        console.log(`resultado = ${clientes}`); 
        this.clientes = clientes.result;
        this.pagination = clientes.pagination;
        this.toastr.success('Clientes carregados com sucesso');
      },
      (error: any) => {
        console.error(error);
        this.toastr.error('Erro ao carregar os clientes');
        this.spinner.hide();
      }, () => this.spinner.hide()
    );
  }

  pageChanged(event: any): void {
    console.log(`pagina trocada = ${event.page}`);
    this.pagination.currentPage = event.page;
    this.carregarClientes();
  }

  editarCliente(clienteId : number){
    this.router.navigate(['/editor', clienteId]);
  }

}
