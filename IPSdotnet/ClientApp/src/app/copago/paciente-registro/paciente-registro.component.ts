import { Component, OnInit } from '@angular/core';
import { Paciente } from '../models/paciente';
import { PacienteService } from '../../services/paciente.service';
import { FormGroup, FormBuilder, Validators, AbstractControl} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-paciente-registro',
  templateUrl: './paciente-registro.component.html',
  styleUrls: ['./paciente-registro.component.css']
})
export class PacienteRegistroComponent implements OnInit {

  paciente: Paciente;
  formGroup: FormGroup;
  constructor(private pacienteService: PacienteService, private formBuilder: FormBuilder, private modalService: NgbModal  ) { }

  ngOnInit() {
    this.paciente = new Paciente();
        this.buildForm();

  }

    private buildForm() {
          this.paciente = new Paciente();
          this.paciente.identificacion = '';
          this.paciente.nombre = '';
          this.paciente.copago = 0;
          this.formGroup = this.formBuilder.group({
            identificacion: [this.paciente.identificacion, Validators.required],
            nombre: [this.paciente.nombre, Validators.required],
            valorServ: [this.paciente.valorServ, [Validators.required]],
            salario: [this.paciente.salario, [Validators.required, Validators.min(1)]]
          });
      }
    get control() {
      return this.formGroup.controls;
       }
      onSubmit() {
            if (this.formGroup.invalid) {
              return;
            }
            this.add();
          }
add() {
      this.paciente = this.formGroup.value;
   this.pacienteService.post(this.paciente).subscribe(p => {
      if (p != null) {
        const messageBox = this.modalService.open (AlertModalComponent);
        messageBox.componentInstance.title = 'Resultado Operación';
        messageBox.componentInstance.message = 'Paciente creada!!! :-)';
        this.paciente = p;
      }
    });
  }

}
