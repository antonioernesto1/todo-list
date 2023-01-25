import { Component, OnInit, TemplateRef } from '@angular/core';
import { Tarefa } from 'src/app/models/tarefa';
import { TodoService } from 'src/app/services/todo-service.service';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { faPen } from '@fortawesome/free-solid-svg-icons';
import { faEraser } from '@fortawesome/free-solid-svg-icons';
import { faCheck } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent implements OnInit {
  modalRef!: BsModalRef;
  constructor(
    private todoService: TodoService,
    private modalService: BsModalService
  ) {}

  conteudo!: string;
  tarefa!: Tarefa;
  private _filtro: string = '';
  idParaExcluir: number = 0;
  tarefas!: Tarefa[];
  tarefasFiltradas: Tarefa[] = [];
  conteudoParaEditar: string = '';
  tarefaParaEditar: Tarefa = {
    id: 0,
    conteudo: '',
    diaTarefa: new Date(Date.now()),
  };

  ngOnInit(): void {
    this.getTarefas();
    this.tarefa = {
      id: 0,
      conteudo: '',
      diaTarefa: new Date(Date.now()),
    };
  }

  openDeleteModal(template: TemplateRef<any>, id: number) {
    this.modalRef = new BsModalRef();
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
    this.idParaExcluir = id;
  }

  openEditModal(template: TemplateRef<any>, tarefa: Tarefa) {
    this.modalRef = new BsModalRef();
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
    this.tarefaParaEditar = tarefa;
  }

  public get filtro(): string {
    return this._filtro;
  }

  public set filtro(value: string) {
    this._filtro = value;
    if (this._filtro) {
      this.filtrarTarefas(this.filtro);
    } else {
      this.tarefasFiltradas = this.tarefas;
    }
  }

  filtrarTarefas(filtrarPor: string) {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    this.tarefasFiltradas = this.tarefas.filter((f) =>
      f.conteudo.toLocaleLowerCase().includes(filtrarPor)
    );
  }

  addTarefa() {
    if (this.conteudo) {
      this.tarefa.conteudo = this.conteudo;
      this.tarefa.diaTarefa = new Date(Date.now());

      this.todoService.addTarefa(this.tarefa).subscribe();
      location.reload();
    } else {
      alert('Tarefa vazia');
    }
  }

  getTarefas() {
    this.todoService.getTarefas().subscribe((tarefas) => {
      this.tarefas = tarefas;
      this.tarefasFiltradas = tarefas;
    });
  }

  deleteTarefa(id: number): void {
    this.todoService.deleteTarefa(id).subscribe();
    this.modalRef?.hide;
    location.reload();
  }

  editTarefa(tarefa: Tarefa) {
    tarefa.conteudo = this.conteudoParaEditar;
    this.todoService.updateTarefa(tarefa.id, tarefa).subscribe();
    this.modalRef?.hide();
  }

  closeModal() {
    this.modalRef?.hide();
  }

  resetFiltro(): void {
    this.filtro = '';
  }

  faPlus = faPlus;
  faTrash = faTrash;
  faPen = faPen;
  faEraser = faEraser;
  faCheck = faCheck;
}
