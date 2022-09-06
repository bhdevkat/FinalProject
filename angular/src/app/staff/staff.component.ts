import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  StaffServiceProxy,
  StaffDto,
  StaffDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateStaffDialogComponent } from './create-staff/create-staff-dialog.component';
import { EditStaffDialogComponent } from './edit-staff/edit-staff-dialog.component';

class PagedStaffesRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  animations: [appModuleAnimation()]
})

export class StaffComponent extends PagedListingComponentBase<StaffDto> {
    myStaff: StaffDto[] = [];
    keyword = '';
    isActive: boolean | null;
    advancedFiltersVisible = false;    
  
    constructor(
      injector: Injector,
      private _staffesService: StaffServiceProxy,
      private _modalService: BsModalService
    ) {
      super(injector);
    }
  
    list(
      request: PagedStaffesRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
      request.keyword = this.keyword;
  
      this._staffesService
        .getAll(request.keyword, request.skipCount, request.maxResultCount)
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: StaffDtoPagedResultDto) => {
          this.myStaff = result.items;
          this.showPaging(result, pageNumber);
        });
    }
  
    delete(staff: StaffDto): void {
      abp.message.confirm(
        this.l('StaffDeleteWarningMessage', staff.staffNumber),
        undefined,
        (result: boolean) => {
          if (result) {
            this._staffesService
              .delete(staff.id)
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
  
    createStaff(): void {
      this.showCreateOrEditStaffDialog();
    }
  
    editStaff(staff: StaffDto): void {
      this.showCreateOrEditStaffDialog(staff.id);
    }
  
    showCreateOrEditStaffDialog(id?: number): void {
      let createOrEditStaffDialog: BsModalRef;
      if (!id) {
        createOrEditStaffDialog = this._modalService.show(
          CreateStaffDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } else {
        createOrEditStaffDialog = this._modalService.show(
          EditStaffDialogComponent,
          {
            class: 'modal-lg',
            initialState: {
              id: id,
            },
          }
        );
      }
  
      createOrEditStaffDialog.content.onSave.subscribe(() => {
        this.refresh();
      });
    }
  }
  