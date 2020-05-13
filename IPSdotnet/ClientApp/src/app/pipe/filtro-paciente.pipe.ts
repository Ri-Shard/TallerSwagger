import { Pipe, PipeTransform } from '@angular/core';
import { Paciente } from '../copago/models/paciente';

@Pipe({
  name: 'filtroPaciente'
})
export class FiltroPacientePipe implements PipeTransform {

  transform(paciente: Paciente[], searchText: string): any {
    if (searchText == null) { return paciente; }
   return paciente.filter(p =>
   p.identificacion.toLowerCase()
  .indexOf(searchText.toLowerCase()) !== -1);
    }
  }
