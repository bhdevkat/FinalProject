import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PersonDto, StaffDto, StaffServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-staff',
  templateUrl: './edit-staff-dialog.component.html'
})
export class EditStaffDialogComponent extends AppComponentBase  
implements OnInit {
  saving = false;
  staff: StaffDto = new StaffDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(injector: Injector,
    public _staffService: StaffServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    this.staff.person = new PersonDto();
  }

  ngOnInit(): void {
    this._staffService.get(this.id).subscribe((result) => {
      this.staff = result;
    });
  }
  save(): void {
    this.saving = true;

    this._staffService.update(this.staff).subscribe(
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
