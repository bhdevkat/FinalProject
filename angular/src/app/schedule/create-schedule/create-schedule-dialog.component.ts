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
  ScheduleServiceProxy,
  CreateScheduleDto,
  DropdownItemDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule-dialog.component.html'
})

export class CreateScheduleDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  schedule = new CreateScheduleDto();
  dropdownList = new DropdownItemDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _scheduleService: ScheduleServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {  
    this._scheduleService.getDropdrownData().subscribe((result: DropdownItemDto) => {
      if(result != null)      
        this. dropdownList = result;
    });    
  }
 
  save(): void {
    this.saving = true;
    this._scheduleService
      .create(this.schedule)
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
