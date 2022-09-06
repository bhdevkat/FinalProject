import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ScheduleServiceProxy,
  ScheduleDto,
  DropdownItemDto
} from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-schedule',
  templateUrl: './edit-schedule-dialog.component.html'
})

export class EditScheduleDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  schedule: ScheduleDto = new ScheduleDto();
  dropdownList = new DropdownItemDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _scheduleService: ScheduleServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._scheduleService.get(this.id).subscribe((result: ScheduleDto) => {
      this.schedule = result;
      this._scheduleService.getDropdrownData().subscribe((result: DropdownItemDto) => {
        if(result != null)      
          this. dropdownList = result;
      }); 
    });
  }

  save(): void {
    this.saving = true;

    this._scheduleService.update(this.schedule).subscribe(
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
