import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  ScheduleServiceProxy,
  ScheduleDto,
  ScheduleDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateScheduleDialogComponent } from './create-schedule/create-schedule-dialog.component';
import { EditScheduleDialogComponent } from './edit-schedule/edit-schedule-dialog.component';

class PagedScheduleesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  animations: [appModuleAnimation()]
})

export class ScheduleComponent extends PagedListingComponentBase<ScheduleDto> {
    schedules: ScheduleDto[] = [];
    keyword = '';
  
    constructor(
      injector: Injector,
      private _schedulesService: ScheduleServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedScheduleesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._schedulesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: ScheduleDtoPagedResultDto) => {
          this.schedules = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(schedule: ScheduleDto): void {
      abp.message.confirm(
        this.l('ScheduleDeleteWarningMessage', schedule.driverName),
        undefined,
        (result: boolean) => {
          if (result) {
            this._schedulesService
              .delete(schedule.id)
              .pipe(
                finalize(() => {
                  abp.notify.success(this.l('SuccessfullyDeleted'));
                  this.refresh();
                })
              )
              .subscribe(() => {});
          }
        }
      );
    }
  
    createSchedule(): void {
      this.showCreateOrEditScheduleDialog();
    }
  
    editSchedule(schedule: ScheduleDto): void {
      this.showCreateOrEditScheduleDialog(schedule.id);
    }
  
    showCreateOrEditScheduleDialog(id?: number): void {
      let createOrEditScheduleDialog: BsModalRef;
      if (!id) {
        createOrEditScheduleDialog = this._modalService.show(
          CreateScheduleDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditScheduleDialog = this._modalService.show(
          EditScheduleDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditScheduleDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  