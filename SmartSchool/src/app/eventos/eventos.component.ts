import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  titulo = "Eventos";

  public eventoSelecionado!: string;

  public eventos = [
    {id: 1, tipo: "Compartilhado", descricao: "", nome: "Chamada Zoom", dataevento: "", local: "", participante: ""  },
    {id: 2, tipo: "EXclusivo", descricao: "", nome: "Chamada Whatsapp", dataevento: "", local: "", participante: "" },
    {id: 3, tipo: "Compartilhado", descricao: "", nome: "Almoço", dataevento: "", local: "", participante: "" },
    {id: 4, tipo: "Exclusivo", descricao: "", nome: "Ligação", dataevento: "", local: "", participante: "" },
    {id: 5, tipo: "Compartilhado", descricao: "", nome: "Reunião", dataevento: "", local: "", participante: "" }
  ];

  eventoSelect(evento: any) {
    this.eventoSelecionado = evento.nome;

  }

  voltar() {
    this.eventoSelecionado = '';
  }

  constructor() { }

  ngOnInit(): void {
  }

}
