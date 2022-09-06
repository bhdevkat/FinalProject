import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { HomeComponent } from '@app/home/home.component';
import { AboutComponent } from '@app/about/about.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// layout
import { HeaderComponent } from './layout/header.component';
import { HeaderLeftNavbarComponent } from './layout/header-left-navbar.component';
import { HeaderLanguageMenuComponent } from './layout/header-language-menu.component';
import { HeaderUserMenuComponent } from './layout/header-user-menu.component';
import { FooterComponent } from './layout/footer.component';
import { SidebarComponent } from './layout/sidebar.component';
import { SidebarLogoComponent } from './layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from './layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from './layout/sidebar-menu.component';
//Student
import { StudentComponent } from './student/student.component';
import { CreateStudentDialogComponent } from './student/create-student/create-student-dialog.component';
import { EditStudentDialogComponent } from './student/edit-student/edit-student-dialog.component';
//Staff
import { StaffComponent } from './staff/staff.component';
import { EditStaffDialogComponent } from './staff/edit-staff/edit-staff-dialog.component';
import { CreateStaffDialogComponent } from './staff/create-staff/create-staff-dialog.component';
//Bus
import { BusComponent } from './bus/bus.component';
import { CreateBusDialogComponent } from './bus/create-bus/create-bus-dialog.component';
import { EditBusDialogComponent } from './bus/edit-bus/edit-bus-dialog.component';
//Location
import { LocationComponent } from './location/location.component';
import { CreateLocationDialogComponent } from './location/create-location/create-location-dialog.component';
import { EditLocationDialogComponent } from './location/edit-location/edit-location-dialog.component';
//Boarding
import { BoardingComponent } from './boarding/boarding.component';
import { CreateBoardingDialogComponent } from './boarding/create-boarding/create-boarding-dialog.component';
import { EditBoardingDialogComponent } from './boarding/edit-boarding/edit-boarding-dialog.component';
//Trip
import { TripComponent } from './trip/trip.component';
import { CreateTripDialogComponent } from './trip/create-trip/create-trip-dialog.component';
import { EditTripDialogComponent } from './trip/edit-trip/edit-trip-dialog.component';

//Schedule
import { ScheduleComponent } from './schedule/schedule.component';
import { CreateScheduleDialogComponent } from './schedule/create-schedule/create-schedule-dialog.component';
import { EditScheduleDialogComponent } from './schedule/edit-schedule/edit-schedule-dialog.component';

import { WebcamModule } from 'ngx-webcam';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    // tenants
    TenantsComponent,
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    RolesComponent,
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    UsersComponent,
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ChangePasswordComponent,
    ResetPasswordDialogComponent,
    // layout
    HeaderComponent,
    HeaderLeftNavbarComponent,
    HeaderLanguageMenuComponent,
    HeaderUserMenuComponent,
    FooterComponent,
    SidebarComponent,
    SidebarLogoComponent,
    SidebarUserPanelComponent,
    SidebarMenuComponent,
    //Trip
    TripComponent,
    EditTripDialogComponent,
    CreateTripDialogComponent,
    //Bus
    BusComponent,
    EditBusDialogComponent,
    CreateBusDialogComponent,
    //Student
    StudentComponent,
    CreateStudentDialogComponent,
    EditStudentDialogComponent,
    //Boarding
    BoardingComponent,
    CreateBoardingDialogComponent,
    EditBoardingDialogComponent,
    //Staff
    StaffComponent,
    EditStaffDialogComponent,
    CreateStaffDialogComponent,
    //Trip
    TripComponent,
    CreateTripDialogComponent,
    EditTripDialogComponent,
    //Location
    LocationComponent,
    CreateLocationDialogComponent,
    EditLocationDialogComponent,
    //Location
    ScheduleComponent,
    CreateScheduleDialogComponent,
    EditScheduleDialogComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    WebcamModule
  ],
  providers: [],
  entryComponents: [
    // tenants
    CreateTenantDialogComponent,
    EditTenantDialogComponent,
    // roles
    CreateRoleDialogComponent,
    EditRoleDialogComponent,
    // users
    CreateUserDialogComponent,
    EditUserDialogComponent,
    ResetPasswordDialogComponent,
    //Trip
    EditTripDialogComponent,
    CreateTripDialogComponent,
    //Bus
    EditBusDialogComponent,
    CreateBusDialogComponent,
    //Student
    CreateStudentDialogComponent,
    EditStudentDialogComponent,
    //Boarding
    CreateBoardingDialogComponent,
    EditBoardingDialogComponent,
    //Staff
    EditStaffDialogComponent,
    CreateStaffDialogComponent,
    //Trip
    CreateTripDialogComponent,
    EditTripDialogComponent,
    //Location
    CreateLocationDialogComponent,
    EditLocationDialogComponent,
    //Location
    CreateScheduleDialogComponent,
    EditScheduleDialogComponent,
  ],
})
export class AppModule {}
