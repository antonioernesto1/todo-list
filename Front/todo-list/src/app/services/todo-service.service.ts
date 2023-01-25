import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tarefa } from '../models/tarefa';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}
  private apiUrl: string = 'https://localhost:7262/api/Tarefas';
  getTarefas(): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(this.apiUrl);
  }
  addTarefa(tarefa: Tarefa): Observable<Tarefa> {
    return this.http.post<Tarefa>(this.apiUrl, tarefa);
  }
  deleteTarefa(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  updateTarefa(id: number, model: Tarefa) {
    return this.http.put(`${this.apiUrl}/${id}`, model);
  }
}
