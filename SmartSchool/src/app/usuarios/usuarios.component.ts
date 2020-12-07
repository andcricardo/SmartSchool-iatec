            import { Component, OnInit } from '@angular/core';
  import { FormGroup, FormBuilder, Validators } from '@angular/forms';
  import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
  import { ToastrService } from 'ngx-toastr';
  import { NgxSpinnerService } from 'ngx-spinner';
  import { Subject } from 'rxjs';
  import { ActivatedRoute } from '@angular/router';
import { Usuarios } from '../models/Usuarios';
import { UsuariosService } from './usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit  {
  titulo = "Usuários";

  public usuarioSelecionado!: string;

  public usuarios = [] as any;

  public modalRef: BsModalRef | undefined;
  public usuarioForm: FormGroup | undefined;

  public textSimple: string | undefined;

  private unsubscriber = new Subject();


  public msnDeleteUsuario: string | undefined;
  public modeSave = 'post';

  usuarioSelect(usuario: any) {
    this.usuarioSelecionado = usuario.nome;

  }

  voltar() {
    this.usuarioSelecionado = '';
  }

  constructor(  private usuarioService: UsuariosService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
      this.criarForm();
     }

   ngOnInit(): void {
    this.carregarUsuarios();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }

  criarForm() {
    this.usuarioForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
      datanascimento: ['', Validators.required],
      sexo: ['', Validators.required]
    });
  }

  carregarUsuarios()
  {
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuarios[]) => {
        this.usuarios = usuarios;
      },
      (error: any) => {console.error(error);
      }
      );
  }

}
