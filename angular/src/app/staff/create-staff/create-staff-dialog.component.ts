import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  StaffServiceProxy,
  CreateStaffDto,
  CreatePersonDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-staff',
  templateUrl: './create-staff-dialog.component.html'
})

export class CreateStaffDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  staff = new CreateStaffDto();  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _staffService: StaffServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    //this.staff.person = new Person();
  }

  ngOnInit(): void {
    
    this.staff.person= new CreatePersonDto();
    //this.staff.person.firstname
  }
 
  save(): void {
    this.saving = true;
    this._staffService
      .create(this.staff)
      .subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
      );
  }
}
