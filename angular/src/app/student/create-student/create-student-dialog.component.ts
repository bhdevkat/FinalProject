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
  StudentServiceProxy,
  CreateStudentDto,
  CreatePersonDto,
  TagDto,
  TagServiceProxy
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student-dialog.component.html'
})

export class CreateStudentDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  student = new CreateStudentDto(); 
  tags: TagDto[]; 

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _studentService: StudentServiceProxy,
    public _tagService: TagServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    //this.student.person = new Person();    
  }

  ngOnInit(): void {    
    this.student.person= new CreatePersonDto();
    this._tagService.getDropdrownData().subscribe((result: TagDto[]) => {
      if(result != null)      
        this.tags = result;  
        //this.student.person.tagId 
    });
  }
 
  save(): void {
    this.saving = true;
    this._studentService
      .create(this.student)
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
