import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { PersonDto, StudentDto, StudentServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student-dialog.component.html'
})
export class EditStudentDialogComponent extends AppComponentBase  
implements OnInit {
  saving = false;
  student: StudentDto = new StudentDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(injector: Injector,
    public _studentService: StudentServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    this.student.person = new PersonDto();
  }

  ngOnInit(): void {
    this._studentService.get(this.id).subscribe((result) => {
      this.student = result;
    });
  }
  save(): void {
    this.saving = true;

    this._studentService.update(this.student).subscribe(
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
